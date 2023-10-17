import GamesList from "./GamesList";

const tg = window.Telegram.WebApp;

export default function App() {

    React.useEffect(() => {
        tg.expand();
        tg.enableClosingConfirmation();

        tg.MainButton.hide();
    }, []);

    return (
        <div className="app">
            <GamesList />
        </div>
    );
}