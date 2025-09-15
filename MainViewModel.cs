using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NAudio.CoreAudioApi;

namespace VolumeWpfApp
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly MMDeviceEnumerator _enumerator = new();
        private readonly MMDevice _device;

        public MainViewModel()
        {
            _device = _enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            UpdateMutedState();
        }

        [ObservableProperty]
        private string isMutedText = "状態: 不明";

        [RelayCommand]
        private void Mute()
        {
            _device.AudioEndpointVolume.Mute = true;
            UpdateMutedState();
        }

        [RelayCommand]
        private void Unmute()
        {
            _device.AudioEndpointVolume.Mute = false;
            UpdateMutedState();
        }

        private void UpdateMutedState()
        {
            IsMutedText = _device.AudioEndpointVolume.Mute ? "状態: ミュート中" : "状態: ミュート解除";
        }
    }
}
