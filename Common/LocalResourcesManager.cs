using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows;
using System.Windows.Resources;

namespace Common
{
    public class LocalResourcesManager : DependencyObject
    {
        private static readonly IDictionary<FrameworkElement, IDictionary<CultureInfo, ResourceDictionary>> localResources = new Dictionary<FrameworkElement, IDictionary<CultureInfo, ResourceDictionary>>();

        public static CultureInfo[] AvailableCultures { get { return localResources.SelectMany(d => d.Value.Keys).ToArray(); } }

        public static CultureInfo CurrentCulture { get { return Thread.CurrentThread.CurrentUICulture; } }

        public static string GetPath(FrameworkElement control)
        {
            return (string)control.GetValue(PathProperty);
        }

        public static void SetPath(FrameworkElement control, string value)
        {
            control.SetValue(PathProperty, value);
        }

        public static readonly DependencyProperty PathProperty = DependencyProperty.RegisterAttached("Path", typeof(string), typeof(LocalResourcesManager), new PropertyMetadata(OnPathChanged));

        private static void OnPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)d;
            string path = (string)e.NewValue;

            Assembly assembly = element.GetType().Assembly;

            // string[] tokens = path.Split(';');

            // Assembly assembly = Assembly.GetEntryAssembly();

            string assemblyName = assembly.GetName().Name;

            string resourcePackName = assemblyName + ".g.resources";

            using (Stream stream = assembly.GetManifestResourceStream(resourcePackName))
            {
                using (ResourceReader reader = new ResourceReader(stream))
                {
                    localResources[element] = new Dictionary<CultureInfo, ResourceDictionary>();

                    foreach (DictionaryEntry entry in reader.Cast<DictionaryEntry>()
                                              .Where(de => (de.Key as string).StartsWith(path, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        string cultureName = System.IO.Path.GetFileName(entry.Key as string).Split('.')[0];

                        CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);

                        Uri uri = new Uri("/" + assemblyName + ";component/" + entry.Key as string, UriKind.Relative);

                        StreamResourceInfo info = Application.GetResourceStream(uri);

                        localResources[element][culture] = (ResourceDictionary)System.Windows.Markup.XamlReader.Load(info.Stream);
                    }
                }
            }

            RefreshLocalResources();
        }

        public static void RefreshLocalResources()
        {
            foreach (FrameworkElement element in localResources.Keys)
            {
                foreach (ResourceDictionary rd in localResources[element].Values)
                {
                    element.Resources.MergedDictionaries.Remove(rd);
                }

                if (localResources[element].ContainsKey(CurrentCulture))
                {
                    element.Resources.MergedDictionaries.Add(localResources[element][CurrentCulture]);
                }
            }
        }

        /*static LocalResourcesManager()
        {
            Assembly applicationAssembly = Assembly.GetEntryAssembly();

            string resourcePackName = applicationAssembly.GetName().Name + ".g.resources";

            using (Stream stream = applicationAssembly.GetManifestResourceStream(resourcePackName))
            {
                using (ResourceReader reader = new ResourceReader(stream))
                {
                    foreach (DictionaryEntry entry in reader.Cast<DictionaryEntry>()
                                              .Where(e => (e.Key as string).StartsWith("LocalResources/", StringComparison.InvariantCultureIgnoreCase)))
                    {
                        CultureInfo culture = CultureInfo.GetCultureInfo((entry.Key as string).Split('/')[1].Split('.')[0]);

                        Uri uri = new Uri(entry.Key as string, UriKind.Relative);

                        StreamResourceInfo info = Application.GetResourceStream(uri);

                        localResources[culture] = (ResourceDictionary)System.Windows.Markup.XamlReader.Load(info.Stream);                        
                    }
                }
            }
        }*/

        /*public static void LoadLocalResources()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;

            foreach (ResourceDictionary rd in localResources.Values)
            {
                Application.Current.Resources.MergedDictionaries.Remove(rd);
            }

            Application.Current.Resources.MergedDictionaries.Add(localResources[currentCulture]);
        }*/
    }
}
