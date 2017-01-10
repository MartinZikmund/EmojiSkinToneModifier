using EmojiSkinToneModifier.Portable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EmojiSkinToneModifier.SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Actual usage
        /// </summary>
        private void UpdateResult()
        {
            Result = Emoji.ChangeSkinTone(SelectedSkinTone.SkinTone);
        }

        public SkinToneItem[] SkinTones { get; } = new SkinToneItem[]
        {
            new SkinToneItem( EmojiSkinTone.Type12 ),
            new SkinToneItem( EmojiSkinTone.Type3 ),
            new SkinToneItem( EmojiSkinTone.Type4 ),
            new SkinToneItem( EmojiSkinTone.Type5 ),
            new SkinToneItem( EmojiSkinTone.Type6 )
        };

        private string _emoji = "";
        public string Emoji
        {
            get
            {
                return _emoji;
            }
            set
            {
                _emoji = value;
                OnPropertyChanged();
                UpdateResult();
            }
        }

        private SkinToneItem _selectedSkinTone = null;
        public SkinToneItem SelectedSkinTone
        {
            get
            {
                return _selectedSkinTone ?? SkinTones.First();
            }
            set
            {
                _selectedSkinTone = value;
                OnPropertyChanged();
                UpdateResult();
            }
        }

        private string _result = "";
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
