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

namespace GlobalizationSample
{
    public class LocalResourcesManager
    {
        private static readonly IDictionary<CultureInfo, ResourceDictionary> localResources = new Dictionary<CultureInfo, ResourceDictionary>();

        public static CultureInfo[] AvailableCultures { get { return localResources.Keys.ToArray(); } }

        public static CultureInfo CurrentCulture { get { return Thread.CurrentThread.CurrentUICulture; } }

        static LocalResourcesManager()
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
        }

        public static void LoadLocalResources()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;

            foreach (ResourceDictionary rd in localResources.Values)
            {
                Application.Current.Resources.MergedDictionaries.Remove(rd);
            }

            Application.Current.Resources.MergedDictionaries.Add(localResources[currentCulture]);
        }
    }
}
