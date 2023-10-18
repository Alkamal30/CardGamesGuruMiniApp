import React, { useEffect } from 'react';
import GamesList from "./GamesList";

const tg = window.Telegram.WebApp;

export default function App() {

    useEffect(() => {
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