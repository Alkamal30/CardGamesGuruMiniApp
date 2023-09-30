function Card() {
    return (
        <div className="card">
            <div className="card-head">
                This or That
            </div>
            <div className="card-body">
                <div className="card-body__question">
                    Go back in time and meet your ancestors
                </div>  
                <div className="card-body__split-line">
                    <div className="card-body__split-circle">
                        <p>or</p>
                    </div>
                </div>
                <div className="card-body__question">
                    Go to the future and meet your great grandchildren  
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