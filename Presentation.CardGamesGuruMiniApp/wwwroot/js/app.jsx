const tg = window.Telegram.WebApp;

tg.expand();
tg.enableClosingConfirmation();

tg.MainButton.color = "#31B545";
tg.MainButton.hide();


// function Card() {
//     const [firstQuestion, setFirstQuestion] = React.useState('Example First Question');
//     const [secondQuestion, setSecondQuestion] = React.useState('Example Second Question');

//     React.useEffect(() => {
//         tg.MainButton.onClick(nextCard);
//         return () => {
//             tg.MainButton.offClick(nextCard);
//         }
//     }, [nextCard])

//     function nextCard() {
//         fetch('/api/tot/cardrandom/')
//             .then(response => response.json())
//             .then(card => {
//                 console.log(card);
//                 setFirstQuestion(card.firstQuestion);
//                 setSecondQuestion(card.secondQuestion);
//             });
//     }
    
//     return (
//         <div className="card">
//             <div className="card-head">
//                 This or That
//             </div>
//             <div className="card-body">
//                 <div className="card-body__question">
//                     { firstQuestion }
//                 </div>  
//                 <div className="card-body__split-line">
//                     <div className="card-body__split-circle">
//                         <p>or</p>
//                     </div>
//                 </div>
//                 <div className="card-body__question">
//                     { secondQuestion }
//                 </div>
//             </div>
//         </div>
//     );
// }

function Game(props) {
    return (
       <div className="game">
            <div className="game-title">{props.title}</div>
       </div> 
    );
}

function GamesList() {
    const [allGames, setAllGames] = React.useState([]);

    React.useEffect(() => {
        getAllGames();
    });

    function getAllGames() {
        fetch('/api/game/games')
            .then(response => response.json())
            .then(games => {
                setAllGames(games);
            });
    }

    return (
        <div className="games-list">
            {
                allGames.map(game => <Game title={game.name} />)
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