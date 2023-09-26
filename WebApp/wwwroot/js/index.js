const tg = window.Telegram.WebApp;

tg.expand();

tg.MainButton.text = 'Reload Page';
tg.MainButton.show();

Telegram.WebApp.onEvent('mainButtonClicked', () => {
    tg.MainButton.showProgress();
    document.getElementsByTagName('body')[0].style.background = "linear-gradient(217deg, rgba(255,0,0,1), rgba(255,0,0,0) 70.71%), linear-gradient(127deg, rgba(0,255,0,1), rgba(0,255,0,0) 70.71%), linear-gradient(336deg, rgba(0,0,255,1), rgba(0,0,255,0) 70.71%)";

    setTimeout(() => {
        tg.MainButton.hideProgress();
        location.reload();
    }, 1500);
});