from fastapi import APIRouter,Depends,HTTPException,status
from sqlalchemy.orm import Session
from .. import database, oauth2, schemas, models,utils

router = APIRouter(tags=["Authentication"])

@router.post('/login')
def login(user_creds:schemas.UserLogin,db:Session=Depends(database.get_db)):
    user = db.query(models.User).filter(models.User.email == user_creds.email).first()

    if not user:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND,detail=f'invalid creds')
    
    if not utils.verify(user_creds.password,user.password):
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND,detail=f'invalid creds')
    
    access_token = oauth2.create_access_token(data={"user_id":user.id})

    return {"access_token":access_token, "token_type":"bearer"}