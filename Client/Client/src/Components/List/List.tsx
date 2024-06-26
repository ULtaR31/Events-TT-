﻿import React, {useContext, useEffect} from 'react';
import './List.scss';
import {NavLink, Route, Routes, useNavigate} from "react-router-dom";
import {Context} from "../../index";
import {IEvent} from "../../models/Event";
import {observer} from "mobx-react-lite";
import EventsService from "../../services/EventsService";
interface ListProps {
}

const List: React.FC<ListProps> = (
    {
        
    }
    ) => {
    const history = useNavigate();
    const {store} = useContext(Context);
    // пагинация
    const [page, setPage] = React.useState(1);
    const [events, setEvents] = React.useState<IEvent[]>([]);
    
    let getEvents = async () =>{
        try{
            await EventsService.fetchEvents(page)
                .then((response)=>{
                    if(response.status == 200){
                        setEvents(response.data);
                        setPage(page+1);
                    }else{
                        throw 'Ошибка получения данных';
                    }
                })
        }catch (e:any){
            console.log(e.response?.data?.message);
        }
    }
    
    
    

    useEffect(() => {
        getEvents();
    }, []);
    
    
    
    
    
    return (
        <div className={"list-page"}>
            
            <div className="List-bar">
                <button
                    className={"create-event"}
                    onClick={() => history('/create-event')}
                >Создать мероприятие</button>
            </div>
            
            <div className="list">
                
                {events.length > 0 ?
                    events.map((event, index) => (
                        <div key={index} className="list-item"
                            onClick={() => history(`/event/${event.id}`)}
                        >
                            <p>{event.id}</p>
                            <div className="list-item__image">
                                <img src={event.imageSrc} alt=""/>
                            </div>
                            <div className="list-item__info">
                                <div className="list-item__info__name">
                                    Название:<p>{event.name}</p>
                                </div>
                                <div className="list-item__info__description">
                                    Описание:<p>{event.description}</p>
                                </div>
                                <div className="list-item__info__location">
                                    Локация:<p>{event.location}</p>
                                </div>
                                <div className="list-item__info__date">
                                    Дата:<p>{event?.date?.toString()}</p>
                                </div>
                                <div className="list-item__info__category">
                                    Категория:<p>{event.category}</p>
                                </div>
                                <div className="list-item__info__maxParticipants">
                                    Максимум учасников:<p>{event.maxParticipants}</p>
                                </div>
                            </div>
                        </div>
                    )) : (
                        <h1>Мероприятий нет</h1>
                    )
                
                }
                {events.length > 0 && <button onClick={getEvents}>Загрузить еще</button>}
            </div>

        </div>
    );
};
export default observer(List);