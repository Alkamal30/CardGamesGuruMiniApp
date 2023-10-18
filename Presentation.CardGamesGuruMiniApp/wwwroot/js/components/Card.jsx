import { useState, useEffect } from "react";

const tg = window.Telegram.WebApp;

export default function Card(props) {
    const [firstQuestion, setFirstQuestion] =  useState('');
    const [secondQuestion, setSecondQuestion] = useState('');

    useEffect(() => {
        tg.MainButton.text = "Next Card";
        tg.MainButton.show();
        tg.BackButton.show();

        document.documentElement.style.setProperty('--first-background-color', props.game.colors[0]);
        document.documentElement.style.setProperty('--second-background-color', props.game.colors[1]);
        document.documentElement.style.setProperty('--card-title-font', props.game.font);
        nextCard();
    }, []);

    useEffect(() => {
        tg.MainButton.onClick(nextCard);
        return () => {
            tg.MainButton.offClick(nextCard);
        }
    }, [nextCard]);

    useEffect(() => {
        tg.BackButton.onClick(closeGame);
        return () => {
            tg.BackButton.offClick(closeGame);
        }
    }, [closeGame]);

    function nextCard() {
        tg.MainButton.showProgress();

        fetch(`${props.game.endpoint}/cardrandom/`)
            .then(response => response.json())
            .then(card => {
                setFirstQuestion(props.game.nameIndex == 'tod' ? card.truth : card.firstQuestion);
                setSecondQuestion(props.game.nameIndex == 'tod' ? card.dare : card.secondQuestion);
                tg.MainButton.hideProgress();
            });
    }

    function closeGame() {
        props.close();
    }

    return (
        <div className={`card-block card-block_${props.game.nameIndex}`}>
            <div className="card">
                <div className="card-head">
                    { props.game.name }
                </div>
                <div className="card-body">
                    <div className="card-body__question">
                        { firstQuestion }
                    </div>
                    <div className="card-body__split-line">
                        <div className="card-body__split-circle"></div>
                    </div>
                    <div className="card-body__question">
                        { secondQuestion }
                    </div>
                </div>
            </div>
        </div>
    );
}