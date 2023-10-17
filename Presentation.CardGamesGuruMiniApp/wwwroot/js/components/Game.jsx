const tg = window.Telegram.WebApp;

export default function Game(props) {
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