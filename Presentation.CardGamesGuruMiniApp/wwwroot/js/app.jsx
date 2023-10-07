const tg = window.Telegram.WebApp;

tg.expand();
tg.enableClosingConfirmation();

tg.MainButton.hide();

function Card(props) {
    const [firstQuestion, setFirstQuestion] = React.useState('');
    const [secondQuestion, setSecondQuestion] = React.useState('');

    React.useEffect(() => {
        tg.MainButton.text = "Next Card";
        tg.MainButton.show();
        tg.BackButton.show();

        document.documentElement.style.setProperty('--first-background-color', props.game.colors[0]);
        document.documentElement.style.setProperty('--second-background-color', props.game.colors[1]);
        document.documentElement.style.setProperty('--card-title-font', props.game.font);
        nextCard();
    }, []);

    React.useEffect(() => {
        tg.MainButton.onClick(nextCard);
        return () => {
            tg.MainButton.offClick(nextCard);
        }
    }, [nextCard]);

    React.useEffect(() => {
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

function GameStartMenu(props) {
    const [isGameStarted, setIsGameStarted] = React.useState(false);

    React.useEffect(() => {
        tg.MainButton.text = "Start Game";
        tg.MainButton.show();
        tg.BackButton.show();
    }, []);

    React.useEffect(() => {
        tg.MainButton.onClick(startGame);
        return () => {
            tg.MainButton.offClick(startGame);
        }
    }, [startGame]);

    React.useEffect(() => {
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

function Game(props) {
    return (
       <div className="game" onClick={() => props.clicked(props.game)}
            style={{
                background: `linear-gradient(to right top, ${props.game.colors[0]}, ${props.game.colors[1]})`,
                fontFamily: props.game.font
            }}>
            <div className="game-title">{props.game.name}</div>
       </div>
    );
}

function GamesList() {
    const [allGames, setAllGames] = React.useState([]);
    const [selectedGame, setSelectedGame] = React.useState(null);

    React.useEffect(() => {
        getAllGames();
    }, []);

    function getAllGames() {
        fetch('/api/game/games')
            .then(response => response.json())
            .then(games => {
                setAllGames(games);
            });
    }

    function onGameClicked(game) {
        setSelectedGame(game);
    }

    function closeGame() {
        setSelectedGame(null);
        tg.MainButton.hide();
        tg.BackButton.hide();
    }

    return (
        <div className="games-list-block">
            {
                selectedGame == null ? (
                    <div className="games-list">
                        {
                            allGames.map(game => <Game game={game} clicked={onGameClicked} />)
                        }
                    </div>
                ) : (
                    <GameStartMenu game={selectedGame} close={closeGame} />
                )
            }
        </div>
    );
}

function App() {
    return (
        <div className="app">
            <GamesList />
        </div>
    );
}

ReactDOM.render(
    <App />,
    document.getElementById("root")
);