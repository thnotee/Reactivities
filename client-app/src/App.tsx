import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header } from 'semantic-ui-react';
import List from 'semantic-ui-react/dist/commonjs/elements/List';
import Button from 'semantic-ui-react/dist/commonjs/elements/Button';


function App() {

  const [activites, setActivites] = useState([]);

  useEffect(()=>{
    axios.get('http://localhost:5000/api/activities')
      .then(respose => {
        console.log(respose)
        setActivites(respose.data)
      })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content ='Reactivites' />
        <List>
          {activites.map((activites: any) =>(
            <List.Item key={activites.id}>
            <li key={activites.id}>
              {activites.title}
            </li>
            </List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
