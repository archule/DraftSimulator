
import './App.css';
import Header from './Header.js'
import PlayerTable from './PlayerTable.js';
import Draft from './Draft.js';
import teams from './data/teamData.js'
import CurrentTeam from './CurrentTeam.js'
import SignalRComponent from './SignalRComponent';
import SignupForm from './SignupForm';
import Ticker from './Ticker.js';
import { BrowserRouter as Router, Link, Route, Routes} from "react-router-dom";

const messageTypes = [
    {
        type: 'Type 1',
        messages: ['Message 1', 'Message 2', 'Message 3']
    },
    {
        type: 'Type 2',
        messages: ['Message A', 'Message B', 'Message C']
    }]

function App() {



    
  return (
      <div className="App">
          <Header />
          <section className="teamsContainer">
          <CurrentTeam />
          <CurrentTeam />
          <CurrentTeam />
          <CurrentTeam />
          <CurrentTeam />
          <CurrentTeam />
          <CurrentTeam />
              <CurrentTeam />
          </section>
          <section className="informational">
          </section>
          <Draft />
          <Ticker className="Ticker" messageTypes={messageTypes} />
          { /*
              <Router>
                  <Link state={{ age: "27" }} to="/products" replace={false}>Products</Link>
                  <Routes>
                      <Route exact={true} path="/products/" element={<h1>hi, yo, y</h1>} />
                  </Routes>
              </Router> 
              <SignupForm />
              <SignalRComponent />
              */
          }
          
          
          
       
          
          
          
      </div>
     
    
  );
}

export default App;
