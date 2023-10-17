import Game from "./Game";
import GameStartMenu from "./GameStartMenu";

const tg = window.Telegram.WebApp;

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

export default GamesList;