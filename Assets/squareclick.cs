using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class squareclick : MonoBehaviour
{
    public Transform wtokenObj;
    public Transform btokenObj;
	int bestX;
	int bestY;
	int tempX;
	int tempY;
	public static int[,] weights = new int[8, 8] 
    {{10000,   -3000,   1000,   800,   800,   1000,   -3000,   10000},
    {-3000,  -5000,   -450,   -500,  -500, -450 , -5000,   -3000},
    {1000, -450, 30,  10,  10,  30,  -450, -1000},
    {800,  -500, 10, 50, 50 , 10, -500, 800},
    {10000,   -3000,   1000,   800,   800,   1000,   -3000,   10000},
    {-3000,  -5000,   -450,   -500,  -500, -450 , -5000,   -3000},
    {1000, -450, 30,  10,  10,  30,  -450, -1000},
    {800,  -500, 10, 50, 50 , 10, -500, 800}};
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
		 int x = (int)(transform.position.x+12)/3;
		 int y = (int)(transform.position.y+12)/3;
		 if(canPut(x,y)!=0){
		 	gameflow.newboard[x,y]= gameflow.curturn;
		 	int changed = checkTurn(x,y);
			if (gameflow.curturn == "w")
        	{
				gameflow.wscore += changed+1;
				gameflow.bscore -= changed;
				gameflow.curturn = "b";                
        	}
        	else if (gameflow.curturn == "b")
        	{
				gameflow.bscore += changed+1;
				gameflow.wscore -= changed;
				gameflow.curturn = "w";      
        	} 
		}
		moveAI();     
    }
    
	int checkTurn(int I, int J)
	{	
		int changed = 0;
		string[,] newboard = gameflow.newboard;
		//U
		int j=-1;
		for( j=J+1 ; j<8 ; j++){
			if(String.Compare(newboard[I,j], "e")==0 || String.Compare(newboard[I,j],newboard[I,J])==0){
				break;
			}
		}
		
		if( j!=8 && String.Compare(newboard[I,j],"e")!=0){
			changed +=j-J-1;
			for(int k = J+1; k<j; k++){
				if(String.Compare(newboard[I,J],"b")==0){
						newboard[I,k]="b";
					}
					else{
						
						newboard[I,k]="w";
					}
					
			}
		}
		
		//D
		j=8;
		for( j=J-1 ; j>-1 ; j--){
			if(String.Compare(newboard[I,j], "e")==0 || String.Compare(newboard[I,j],newboard[I,J])==0){
				break;
			}
		}
		
		if( j!=-1 && String.Compare(newboard[I,j],"e")!=0){
			changed +=J-1-j;
			for(int k = J-1; k>j; k--){
				if(String.Compare(newboard[I,J],"b")==0){
						newboard[I,k]="b";
					}
				else{	
					newboard[I,k]="w";
				}
					
			}
		}
		
		//L
		int i=8;
		for( i=I-1 ; i>-1 ; i--){
			if(String.Compare(newboard[i,J], "e")==0 || String.Compare(newboard[i,J],newboard[I,J])==0){
				break;
			}
		}
		
		if( i!=-1 && String.Compare(newboard[i,J],"e")!=0){
			changed += I-1-i;
			for(int k = I-1; k>i; k--){
				if(String.Compare(newboard[I,J],"b")==0){
						newboard[k,J]="b";
					}
					else{	
						newboard[k,J]="w";
					}
					
			}
		}
		
		//R
		i=-1;
		for( i=I+1 ; i<8 ; i++){
			if(String.Compare(newboard[i,J], "e")==0 || String.Compare(newboard[i,J],newboard[I,J])==0){
				break;
			}
		}
		
		if( i!=8 && String.Compare(newboard[i,J],"e")!=0){
			changed +=i-I-1;
			for(int k = I+1; k<i; k++){
				if(String.Compare(newboard[I,J],"b")==0){
						newboard[k,J]="b";
					}
					else{
						
						newboard[k,J]="w";
					}
					
			}
		}
		
		//UR
		i=I+1;
		j=J+1;
		while(i<8 && j<8){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],newboard[I,J])==0){
				break;
			}
			i++;
			j++;
		}
		if( i!=8 && j!=8 && String.Compare(newboard[i,j],"e")!=0){
			int k=I+1;
			int l=J+1;
			changed += i-I-1;
			while(k<i && l<j){
				if(String.Compare(newboard[I,J],"b")==0){
					newboard[k,l]="b";
				}
				else{
					newboard[k,l]="w";
				}
				k++;
				l++;
			}	
		}
		
		//DL
		i=I-1;
		j=J-1;
		while(i>-1 && j>-1){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],newboard[I,J])==0){
				break;
			}
			i--;
			j--;
		}
		if( i!=-1 && j!=-1 && String.Compare(newboard[i,j],"e")!=0){
			int k=I-1;
			int l=J-1;
			changed += I-1-i;
			while(k>i && l>j){
				if(String.Compare(newboard[I,J],"b")==0){
					newboard[k,l]="b";
				}
				else{
					newboard[k,l]="w";
				}
				k--;
				l--;
			}	
		}
		//DR
		i=I+1;
		j=J-1;
		while(i<8 && j>-1){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],newboard[I,J])==0){
				break;
			}
			i++;
			j--;
		}
		if( i!=8 && j!=-1 && String.Compare(newboard[i,j],"e")!=0){
			int k=I+1;
			int l=J-1;
			changed+= i-I-1;
			while(k<i && l>j){
				if(String.Compare(newboard[I,J],"b")==0){
					newboard[k,l]="b";
				}
				else{
					newboard[k,l]="w";
				}
				k++;
				l--;
			}	
		}
		//UL
		i=I-1;
		j=J+1;
		while(i>-1 && j<8){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],newboard[I,J])==0){
				break;
			}
			i--;
			j++;
		}
		if( i!=-1 && j!=8 && String.Compare(newboard[i,j],"e")!=0){
			int k=I-1;
			int l=J+1;
			changed += j-J-1;
			while(k>i && l<j){
				if(String.Compare(newboard[I,J],"b")==0){
					newboard[k,l]="b";
				}
				else{
					newboard[k,l]="w";
				}
				k--;
				l++;
			}	
		}
		gameflow.newboard = newboard;
		return changed;
	}
	
	int canPut(int I, int J)
	{	
		int changed = 0;
		string[,] newboard = gameflow.newboard;
		//U
		int j=-1;
		for( j=J+1 ; j<8 ; j++){
			if(String.Compare(newboard[I,j], "e")==0 || String.Compare(newboard[I,j],gameflow.curturn)==0){
				break;
			}
		}
		
		if( j!=8 && String.Compare(newboard[I,j],"e")!=0){
			changed +=j-J-1;
		}
		
		//D
		j=8;
		for( j=J-1 ; j>-1 ; j--){
			if(String.Compare(newboard[I,j], "e")==0 || String.Compare(newboard[I,j],gameflow.curturn)==0){
				break;
			}
		}
		
		if( j!=-1 && String.Compare(newboard[I,j],"e")!=0){
			changed +=J-1-j;
		}
		
		//L
		int i=8;
		for( i=I-1 ; i>-1 ; i--){
			if(String.Compare(newboard[i,J], "e")==0 || String.Compare(newboard[i,J],gameflow.curturn)==0){
				break;
			}
		}
		
		if( i!=-1 && String.Compare(newboard[i,J],"e")!=0){
			changed += I-1-i;
		}
		
		//R
		i=-1;
		for( i=I+1 ; i<8 ; i++){
			if(String.Compare(newboard[i,J], "e")==0 || String.Compare(newboard[i,J],gameflow.curturn)==0){
				break;
			}
		}
		
		if( i!=8 && String.Compare(newboard[i,J],"e")!=0){
			changed +=i-I-1;
		}
		
		//UR
		i=I+1;
		j=J+1;
		while(i<8 && j<8){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],gameflow.curturn)==0){
				break;
			}
			i++;
			j++;
		}
		if( i!=8 && j!=8 && String.Compare(newboard[i,j],"e")!=0){
			changed += i-I-1;	
		}
		
		//DL
		i=I-1;
		j=J-1;
		while(i>-1 && j>-1){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],gameflow.curturn)==0){
				break;
			}
			i--;
			j--;
		}
		if( i!=-1 && j!=-1 && String.Compare(newboard[i,j],"e")!=0){
			changed += I-1-i;	
		}
		//DR
		i=I+1;
		j=J-1;
		while(i<8 && j>-1){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],gameflow.curturn)==0){
				break;
			}
			i++;
			j--;
		}
		if( i!=8 && j!=-1 && String.Compare(newboard[i,j],"e")!=0){
			changed+= i-I-1;	
		}
		//UL
		i=I-1;
		j=J+1;
		while(i>-1 && j<8){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],gameflow.curturn)==0){
				break;
			}
			i--;
			j++;
		}
		if( i!=-1 && j!=8 && String.Compare(newboard[i,j],"e")!=0){
			changed +=j-J-1;
				
		}
		return changed;
	}
	private void OnMouseEnter(){
		int x = (int)(transform.position.x+12)/3;
		 int y = (int)(transform.position.y+12)/3;
		 if(String.Compare(gameflow.newboard[x,y],"e")==0){
		 	if(canPut(x,y)!=0){
		 		GetComponent<SpriteRenderer>().color = new Color(0,0,1); 
			} 	
		}
	}
	
	private void OnMouseExit(){
		GetComponent<SpriteRenderer>().color = new Color(1,1,1); 
		
	}
	
	void moveAI(){
		if(gameflow.curturn !="w"){
			string[,] temp = gameflow.newboard; 
			//minimax tree
			for(int i=0; i<8; i++){
				for(int j=0; j<8; j++){
					Debug.Log(gameflow.newboard[i,j]);
				}
			}
			minimax(temp,1,-1000000,1000000,"b");
			//find x y
			// add to new board
			gameflow.newboard[bestX,bestY]="b";
			//check change
			gameflow.newboard = checkTurn(bestX,bestY,gameflow.newboard);
			
			gameflow.curturn = "w";
		}
		
	}
	
	double minimax(string[,] temp, int depth,double alpha,double  beta, string maximizingPlayer){
		if(depth == 4){
            return weightedScore(temp, "w");
		}
		if(maximizingPlayer == "b"){
            double maxEval = -1000000;
			for(int i=0; i<8; i++){
				for(int j=0; j<8; j++){
					if(canPut(i,j)!=0){
						string[,] tempp = temp;
						temp[i,j]="b";
						temp = checkTurn(i,j,temp);
						if(depth ==1 ){
							tempX = i;
							tempY = j;
						}
						double eval = minimax(temp, depth+1,alpha,beta,"w");
						if(eval > maxEval){
							bestX= tempX;
							bestY = tempY;
						}
                        maxEval = Mathf.Max(Convert.ToSingle(weightedScore(temp, "b")), Convert.ToSingle(maxEval));
                        alpha = Mathf.Max(Convert.ToSingle(alpha), Convert.ToSingle(eval));
						temp=tempp;
						if (beta <= alpha){
							break;
						}
                        return maxEval;
					}
				}
			}
			return maxEval; 
		}
		else{
            double minEval = 1000000;
			for(int i=0; i<8; i++){
				for(int j=0; j<8; j++){
					if(canPut(i,j)!=0){
						string[,] tempp = temp;
						temp[i,j]="w";
						temp = checkTurn(i,j,temp);
						double eval = minimax(temp, depth+1,alpha,beta,"b");
                        minEval = Mathf.Min(Convert.ToSingle(weightedScore(temp, "w")), Convert.ToSingle(minEval));
                        beta = Mathf.Min(Convert.ToSingle(beta), Convert.ToSingle(eval));
						temp=tempp;
						if(beta<=alpha){
							break;
						}
						return minEval;
					}
				}
			}
			return minEval; 
		}
		return 0;
	}
	
	double weightedScore(string[,] temp, string player){
        double wbscore = 0;
        double wwscore = 0;
        double wscore = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (temp[i,j] == "b")
                {
                    wbscore += weights[i,j] * 0.001;
                }
                else if (temp[i,j] == "w")
                {
                    wwscore += weights[i,j] * 0.001;
                }
            }
        }
        if (player=="w"){
            wscore= wwscore;
        }
        else if (player=="b"){
            wscore=wbscore;
        }

		return wscore;
		
	}
	
	string[,] checkTurn(int I, int J, string[,] newboard)
	{	
		int changed = 0;
		
		//U
		int j=-1;
		for( j=J+1 ; j<8 ; j++){
			if(String.Compare(newboard[I,j], "e")==0 || String.Compare(newboard[I,j],newboard[I,J])==0){
				break;
			}
		}
		
		if( j!=8 && String.Compare(newboard[I,j],"e")!=0){
			changed +=j-J-1;
			for(int k = J+1; k<j; k++){
				if(String.Compare(newboard[I,J],"b")==0){
						newboard[I,k]="b";
					}
					else{
						
						newboard[I,k]="W";
					}
					
			}
		}
		
		//D
		j=8;
		for( j=J-1 ; j>-1 ; j--){
			if(String.Compare(newboard[I,j], "e")==0 || String.Compare(newboard[I,j],newboard[I,J])==0){
				break;
			}
		}
		
		if( j!=-1 && String.Compare(newboard[I,j],"e")!=0){
			changed +=J-1-j;
			for(int k = J-1; k>j; k--){
				if(String.Compare(newboard[I,J],"b")==0){
						newboard[I,k]="b";
					}
				else{	
					newboard[I,k]="W";
				}
					
			}
		}
		
		//L
		int i=8;
		for( i=I-1 ; i>-1 ; i--){
			if(String.Compare(newboard[i,J], "e")==0 || String.Compare(newboard[i,J],newboard[I,J])==0){
				break;
			}
		}
		
		if( i!=-1 && String.Compare(newboard[i,J],"e")!=0){
			changed += I-1-i;
			for(int k = I-1; k>i; k--){
				if(String.Compare(newboard[I,J],"b")==0){
						newboard[k,J]="b";
					}
					else{	
						newboard[k,J]="W";
					}
					
			}
		}
		
		//R
		i=-1;
		for( i=I+1 ; i<8 ; i++){
			if(String.Compare(newboard[i,J], "e")==0 || String.Compare(newboard[i,J],newboard[I,J])==0){
				break;
			}
		}
		
		if( i!=8 && String.Compare(newboard[i,J],"e")!=0){
			changed +=i-I-1;
			for(int k = I+1; k<i; k++){
				if(String.Compare(newboard[I,J],"b")==0){
						newboard[k,J]="b";
					}
					else{
						
						newboard[k,J]="W";
					}
					
			}
		}
		
		//UR
		i=I+1;
		j=J+1;
		while(i<8 && j<8){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],newboard[I,J])==0){
				break;
			}
			i++;
			j++;
		}
		if( i!=8 && j!=8 && String.Compare(newboard[i,j],"e")!=0){
			int k=I+1;
			int l=J+1;
			changed += i-I-1;
			while(k<i && l<j){
				if(String.Compare(newboard[I,J],"b")==0){
					newboard[k,l]="b";
				}
				else{
					newboard[k,l]="W";
				}
				k++;
				l++;
			}	
		}
		
		//DL
		i=I-1;
		j=J-1;
		while(i>-1 && j>-1){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],newboard[I,J])==0){
				break;
			}
			i--;
			j--;
		}
		if( i!=-1 && j!=-1 && String.Compare(newboard[i,j],"e")!=0){
			int k=I-1;
			int l=J-1;
			changed += I-1-i;
			while(k>i && l>j){
				if(String.Compare(newboard[I,J],"b")==0){
					newboard[k,l]="b";
				}
				else{
					newboard[k,l]="W";
				}
				k--;
				l--;
			}	
		}
		//DR
		i=I+1;
		j=J-1;
		while(i<8 && j>-1){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],newboard[I,J])==0){
				break;
			}
			i++;
			j--;
		}
		if( i!=8 && j!=-1 && String.Compare(newboard[i,j],"e")!=0){
			int k=I+1;
			int l=J-1;
			changed+= i-I-1;
			while(k<i && l>j){
				if(String.Compare(newboard[I,J],"b")==0){
					newboard[k,l]="b";
				}
				else{
					newboard[k,l]="W";
				}
				k++;
				l--;
			}	
		}
		//UL
		i=I-1;
		j=J+1;
		while(i>-1 && j<8){
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],newboard[I,J])==0){
				break;
			}
			i--;
			j++;
		}
		if( i!=-1 && j!=8 && String.Compare(newboard[i,j],"e")!=0){
			int k=I-1;
			int l=J+1;
			changed += j-J-1;
			while(k>i && l<j){
				if(String.Compare(newboard[I,J],"b")==0){
					newboard[k,l]="b";
				}
				else{
					newboard[k,l]="W";
				}
				k--;
				l++;
			}	
		}
		return newboard;
	}
}