
import './App.css';
import Header from './Header.js'
import PlayerTable from './PlayerTable.js';
import Draft from './Draft.js';
import teams from './data/teamData.js'
import CurrentTeam from './CurrentTeam.js'
import SignalRComponent from './SignalRComponent';
import SignupForm from './SignupForm';


function App() {

    
  return (
      <div className="App">
          <SignupForm />
          <SignalRComponent />
          <CurrentTeam class="CurrentTeam" />
      <Header />
      <Draft />
     
    </div>
  );
}

export default App;
