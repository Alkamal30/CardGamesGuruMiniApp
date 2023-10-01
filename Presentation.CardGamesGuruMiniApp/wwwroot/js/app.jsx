const tg = window.Telegram.WebApp;

tg.expand();
tg.enableClosingConfirmation();

tg.MainButton.text = "Next Card";
tg.MainButton.color = "#31B545";
tg.MainButton.show();
tg.BackButton.show();


let questions = ['First', 'Second', 'Third'];

function nxtCard() {

}


function Card() {
    const [questionIndex, setQuestionIndex] = React.useState(0);
    const [firstQuestion, setFirstQuestion] = React.useState(questions[0]);
    const [secondQuestion, setSecondQuestion] = React.useState(questions[0]);

    React.useEffect(() => {
        tg.MainButton.onClick(nextCard);
        return () => {
            tg.MainButton.offClick(nextCard);
        }
    }, [nextCard])

    function nextCard() {
        if(questionIndex + 1 >= questions.length) {
            setQuestionIndex(0);
        }
        else {
            setQuestionIndex(questionIndex + 1);
        }

        setFirstQuestion(questions[questionIndex]);
        setSecondQuestion(questions[questionIndex]);
    }
    
    return (
        <div className="card">
            <div className="card-head">
                This or That
            </div>
            <div className="card-body">
                <div className="card-body__question">
                    { firstQuestion }
                </div>  
                <div className="card-body__split-line">
                    <div className="card-body__split-circle">
                        <p>or</p>
                    </div>
                </div>
                <div className="card-body__question">
                    { secondQuestion }
                </div>
            </div>
        </div>
    );
}

function App() {
    return (
        <div className="card-block">
            <Card />
        </div>
    );
}

ReactDOM.render(
    <App />,
    document.getElementById("root")
);