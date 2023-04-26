using System;
using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private OptionMenuView _optionMenuView;
    [SerializeField] private TitleCanvaView _titleCanvaView;


    private List<IDisposable> _disposables = new List<IDisposable>();


    private void Awake()
    {
        var mainManuViewModel = new MainMenuViewModel();
        _mainMenuView.Configure(mainManuViewModel);

        var optionMenuViewModel = new OptionMenuViewModel();
        _optionMenuView.Configure(optionMenuViewModel);
        
        var titleCanvaViewModel = new TitleCanvaViewModel();
        _titleCanvaView.Configure(titleCanvaViewModel);

        var mainMenuUseCase = new MainMenuUseCase();

        var mainMenuPresenter = new MainMenuPresenter(mainManuViewModel);
        _disposables.Add(mainMenuPresenter);
        var mainMenuController = new MainMenuController(mainManuViewModel, mainMenuUseCase);
        _disposables.Add(mainMenuController);

        var titleCanvaPresenter = new TitleCanvaPresenter(titleCanvaViewModel);
        _disposables.Add(titleCanvaPresenter);

        var optionMenuUseCase = new OptionMenuUseCase();

        var optionMenuPresenter = new OptionMenuPresenter(optionMenuViewModel);
        _disposables.Add(optionMenuPresenter);
        var optionMenuController = new OptionMenuController(optionMenuViewModel, optionMenuUseCase);
        _disposables.Add(optionMenuController);
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
