class Ticket extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.ticket };
        this.onClick = this.onClick.bind(this);
    }
    onClick(e) {
        this.props.onRemove(this.state.data);
    }
    render() {
        return <div draggable="true">
            <p><b>Name : {this.state.data.name}</b></p>
            <p><b>Description : {this.state.data.description}</b></p>
            <p><button onClick={this.onClick}>Удалить</button></p>
        </div>;
    }
}

class TicketForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { name: "", description: "" };

        this.onSubmit = this.onSubmit.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
        this.onDescriptionChange = this.onDescriptionChange.bind(this); 
    }
    onNameChange(e) {
        this.setState({ name: e.target.value });
    }
    onDescriptionChange(e) {
        this.setState({ description: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var ticketName = this.state.name.trim();
        var ticketDescription = this.state.description;
        if (!ticketName || !ticketDescription) {
            return;
        }
        this.props.onTicketSubmit({ name: ticketName, description: ticketDescription });
        this.setState({ name: "", description: ""});
    }
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input type="text"
                        placeholder="Название"
                        value={this.state.name}
                        onChange={this.onNameChange} />
                </p>
                <p>
                    <input type="text"
                        placeholder="Описание"
                        value={this.state.description}
                        onChange={this.onDescriptionChange} />
                </p>
                <input type="submit" value="Добавить" />
            </form>
        );
    }
}

class TicketsList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { tickets: [] };

        this.onAddTicket = this.onAddTicket.bind(this);
        this.onRemoveTicket = this.onRemoveTicket.bind(this);
    }

    // загрузка данных
    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText); //xhr.responseText
            this.setState({ tickets: data });
        }.bind(this);
        xhr.send();
    }

    componentDidMount() {
        this.loadData();
    }

    // добавление объекта
    onAddTicket(ticket) {
        if (ticket) {
            var data = JSON.stringify({ "name": ticket.name, "description": ticket.description });
            var xhr = new XMLHttpRequest();

            xhr.open("post", this.props.apiUrl, true);
            xhr.setRequestHeader("Content-type", "application/json");
            xhr.onload = function () {
                if (xhr.status == 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    // удаление объекта
    onRemoveTicket(ticket) {

        if (ticket) {
            var url = this.props.apiUrl + "/" + ticket.id;

            var xhr = new XMLHttpRequest();
            xhr.open("delete", url, true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onload = function () {
                if (xhr.status == 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send();
        }
    }
    render() {
        var remove = this.onRemoveTicket;
        return <div>
            <TicketForm onTicketSubmit={this.onAddTicket} />
            <h2>Список Tickets</h2>
            <div draggable="true">
                {
                    this.state.tickets.map(function (ticket) {
                        return <Ticket key={ticket.id} ticket={ticket} onRemove={remove} />
                    })
                }
            </div>
        </div>;
    }
}

ReactDOM.render(
    <TicketsList apiUrl="/api/values" />,
    document.getElementById("content"),
    
);

//Для обновления надо использовать другую версию функции setState(), 
//которая в качестве параметра принимает функцию.
//Данная функция имеет два параметра: предыдущее состояние объекта state и объект props на момент применения обновления:
//this.setState(function (prevState, props) {
//    return {
//        counter: prevState.counter + props.increment
//    };
//});