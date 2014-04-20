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
        public static readonly DependencyProperty GradeProperty = DependencyProperty.Register("Grade", typeof(uint?), typeof(GradeChooserWidget));

        public uint? Grade
        {
            get { return (uint?)GetValue(GradeProperty); }
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
            Grade = 3;
            UpdateGrade = new DelegateCommand<uint?>(newGrade => Grade = newGrade);
            IncreaseGrade = new DelegateCommand(() => Grade = Math.Min(Grade.Value + 1, 5));
            DecreaseGrade = new DelegateCommand(() => Grade = Math.Max(Grade.Value - 1, 1));
        }
    }
}
