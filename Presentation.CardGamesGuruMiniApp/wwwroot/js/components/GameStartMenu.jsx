import { useState, useEffect } from "react";
import Card from "./Card";

const tg = window.Telegram.WebApp;

export default function GameStartMenu(props) {
    const [isGameStarted, setIsGameStarted] = useState(false);

    useEffect(() => {
        tg.MainButton.text = "Start Game";
        tg.MainButton.show();
        tg.BackButton.show();
    }, []);

    useEffect(() => {
        tg.MainButton.onClick(startGame);
        return () => {
            tg.MainButton.offClick(startGame);
        }
    }, [startGame]);

    useEffect(() => {
        tg.BackButton.onClick(closeGame);
        return () => {
            tg.BackButton.offClick(closeGame);
        }
    }, [closeGame]);

    function startGame() {
        tg.MainButton.showProgress();
        setIsGameStarted(true);
    }

    function closeGame() {
        props.close();
    }

    return (
        <div className="game-screen">
            {
                !isGameStarted ? (
                    <div className="game-start-menu">
                        <div className="game-start-menu__title">
                            { props.game.name }
                        </div>
                        <div className="game-start-menu__description">
                            { props.game.description }
                        </div>
                    </div>
                ) : (
                    <Card close={closeGame} game={props.game} />
                )
            }
        </div>
    )
}