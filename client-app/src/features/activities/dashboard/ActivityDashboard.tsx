
import { observer } from 'mobx-react-lite';
import React from 'react'
import { Grid, List } from 'semantic-ui-react'
import { useStore } from '../../../app/stores/store';
import ActivityDetails from '../details/ActivityDetails';
import ActivityForm from '../form/ActivityForm';
import ActivityList from './Activity';



export default observer(function ActivityDashboard() {

    const{activityStore} = useStore();
    const {editMode} =activityStore;

    return (
        <Grid>
            <Grid.Column width='10'>
                <List>
                    <ActivityList />
                </List>
            </Grid.Column>
            <Grid.Column width='6'>
                {activityStore.selectedActivity && !editMode &&
                <ActivityDetails />}
                {editMode &&
                <ActivityForm />}
                
            </Grid.Column>
        </Grid>
    )
})