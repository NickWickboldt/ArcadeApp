using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeAppNick.Models; 

internal partial class WeatherInfo : ObservableObject
{
    [ObservableProperty]
    private string city;

    [ObservableProperty]
    private string state_country;

    [ObservableProperty]
    private string temperature;

    [ObservableProperty]
    private string weather_icon;

    [RelayCommand]
    private async Task FetchWeatherInformation()
    {

    }
}