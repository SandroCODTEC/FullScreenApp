using Android.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullScreenApp.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        public MainViewModel()
        {
            ChangeImersive = true;
            Fullscreen = true;
            HideNavigation = true;
            Immersive = true;
            ImersiveLabel = ChangeImersive ? "Aplicar FullScreen" : "Remover FullScreen";
        }
        [RelayCommand]
        public async Task ImersiveAsync()
        {
            var window = (Shell.Current as AppShell).Window;
            var decorView = window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = (int)uiOptions;



            if (LowProfile)
            {
                newUiOptions |= (int)SystemUiFlags.LowProfile;
            }
            else
            {
                newUiOptions &= ~(int)SystemUiFlags.LowProfile;
            }
            if (Fullscreen)
            {
                newUiOptions |= (int)SystemUiFlags.Fullscreen;
            }
            else
            {
                newUiOptions &= ~(int)SystemUiFlags.Fullscreen;
            }
            if (HideNavigation)
            {
                newUiOptions |= (int)SystemUiFlags.HideNavigation;
            }
            else
            {
                newUiOptions &= ~(int)SystemUiFlags.HideNavigation;
            }
            if (Immersive)
            {
                newUiOptions |= (int)SystemUiFlags.Immersive;
            }
            else
            {
                newUiOptions &= ~(int)SystemUiFlags.Immersive;
            }
            if (ImmersiveSticky)
            {
                newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            }
            else
            {
                newUiOptions &= ~(int)SystemUiFlags.ImmersiveSticky;
            }

            if (ChangeImersive)
                decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;
            else
                decorView.SystemUiVisibility = (StatusBarVisibility)0;

            window.SetStatusBarColor(Android.Graphics.Color.BlueViolet);
            ChangeImersive = !ChangeImersive;
            ImersiveLabel = ChangeImersive ? "Aplicar FullScreen" : "Remover FullScreen";
        }

        [ObservableProperty]
        public string imersiveLabel;
        [ObservableProperty]
        public bool changeImersive;
        [ObservableProperty]
        public bool lowProfile;
        [ObservableProperty]
        public bool fullscreen;
        [ObservableProperty]
        public bool hideNavigation;
        [ObservableProperty]
        public bool immersive;
        [ObservableProperty]
        public bool immersiveSticky;
    }
}
