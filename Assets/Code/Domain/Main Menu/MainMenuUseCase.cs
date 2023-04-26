using System;
using System.Threading.Tasks;
using UnityEngine;

public class MainMenuUseCase : MainMenuRequest
{
    public async Task Options()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.5f));

        var data = new WelcomeData(welcome: "Menu de Opciones!!");

        EventDispatcherService.Instance.Dispatch(data);
    }
}
