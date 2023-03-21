import { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import {v4 as uuid} from 'uuid';

function App() {

  const [activites, setActivites] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);
  useEffect(()=>{
    axios.get<Activity[]>('http://localhost:5000/api/activities')
      .then(respose => {
        setActivites(respose.data)
      })
  }, [])

  function handleSelectActivity(id:string){
    setSelectedActivity(activites.find(x=> x.id === id));
  }

  function handleCancelSelectActivity(){
    setSelectedActivity(undefined);
  }

  function handleFormOpen(id?:string){
    id ? handleSelectActivity(id) : handleCancelSelectActivity();
    setEditMode(true);
  }

  function handleFormClose(){
    setEditMode(false);
  }

  function handleCreateOrEditActivity(activity:Activity){
    
    activity.id ? 
      setActivites([...activites.filter(x=>x.id !== activity.id),activity])
      : setActivites([...activites, {...activity, id: uuid()}]);
      setEditMode(false);
      setSelectedActivity(activity);
  }

  function handleDeleteActivity(id:string){
    setActivites([...activites.filter(x=>x.id !== id)])
  }

  return (
    <Fragment>
     <NavBar openForm={handleFormOpen}/>
    <Container style={{marginTop: '7em'}}>
      <ActivityDashboard 
        activities={activites}
        selectedActivity={selectedActivity}
        selectActivity={handleSelectActivity}
        cancelSelectActivity={handleCancelSelectActivity}
        editMode ={editMode}
        openForm={handleFormOpen}
        closeForm={handleFormClose}
        createOrEdit={handleCreateOrEditActivity}
        deleteActivity={handleDeleteActivity}
        />
    </Container>
      
    </Fragment>
  );
}

export default App;
