const tg = window.Telegram.WebApp;

tg.MainButton.text = "Reload Page";
tg.MainButton.color = "#31B545";
tg.MainButton.show();
tg.MainButton.showProgress();

Telegram.WebApp.onEvent('mainButtonClicked', function () {
    location.reload();
});

window.onload = (event) => {
    setTimeout(() => {
        tg.MainButton.hideProgress();
    }, 500);
};