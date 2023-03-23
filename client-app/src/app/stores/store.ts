import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";

interface Stroe{
    activityStore: ActivityStore
}

export const store: Stroe ={
    activityStore: new ActivityStore()

}

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext);
}