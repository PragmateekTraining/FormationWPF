using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GradeChooser
{
    public class GradeChooserWidget : Control
    {
        public static readonly DependencyProperty GradeProperty = DependencyProperty.Register("Grade", typeof(int), typeof(GradeChooserWidget), new PropertyMetadata
        {
            CoerceValueCallback = (@do, value) =>
                {
                    if (value == null)
                    {
                        return null;
                    }

                    int newValue = (int)value;

                    newValue = Math.Max(0, Math.Min(5, newValue));

                    return newValue;
                }
        });

        public int Grade
        {
            get { return (int)GetValue(GradeProperty); }
            set { SetValue(GradeProperty, value); }
        }

        public static readonly DependencyProperty UpdateGradeProperty = DependencyProperty.Register("UpdateGrade", typeof(ICommand), typeof(GradeChooserWidget));

        public ICommand UpdateGrade
        {
            get { return (ICommand)GetValue(UpdateGradeProperty); }
            set { SetValue(UpdateGradeProperty, value); }
        }

        public static readonly DependencyProperty IncreaseGradeProperty = DependencyProperty.Register("IncreaseGrade", typeof(ICommand), typeof(GradeChooserWidget));

        public ICommand IncreaseGrade
        {
            get { return (ICommand)GetValue(IncreaseGradeProperty); }
            set { SetValue(IncreaseGradeProperty, value); }
        }

        public static readonly DependencyProperty DecreaseGradeProperty = DependencyProperty.Register("DecreaseGrade", typeof(ICommand), typeof(GradeChooserWidget));

        public ICommand DecreaseGrade
        {
            get { return (ICommand)GetValue(DecreaseGradeProperty); }
            set { SetValue(DecreaseGradeProperty, value); }
        }

        public GradeChooserWidget()
        {
            this.DefaultStyleKey = typeof(GradeChooserWidget);

            Grade = 3;
            UpdateGrade = new DelegateCommand<object>(newGrade => Grade = Convert.ToInt32(newGrade));
            IncreaseGrade = new DelegateCommand(() => Grade = Math.Min(Grade + 1, 5));
            DecreaseGrade = new DelegateCommand(() => Grade = Math.Max(Grade - 1, 1));
        }
    }
}
