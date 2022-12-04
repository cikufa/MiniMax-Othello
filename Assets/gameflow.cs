using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    public Transform squareObj;
	public Transform wtokenObj;
	public Transform btokenObj;
    public static string curturn = "w";
	public static int wscore = 2;
	public static int bscore = 2;
	public static int row = 8;
	public static int col = 8;
	public static string[,] board = new string[row,col];
	public static string[,] newboard = new string[row,col];
	int tempX=0;
	int tempY =0;
	int bestX = 0;
	int bestY = 0;
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
        for (float i =-12 ; i < 12 ; i += 3)
        {
            for (float j =-12 ; j < 12; j += 3)
            {
                Instantiate(squareObj, new Vector2(i, j), squareObj.rotation);
				int r=(int)((i+12)/3);
				int c=(int)((j+12)/3);
				board[r , c]="e";
				newboard[r , c]="e";
				
            }
        }
		board[3,3]="b";
		board[4,4]="b";
		board[3,4]="w";
		board[4,3]="w";
		
		newboard[3,3]="b";
		newboard[4,4]="b";
		newboard[3,4]="w";
		newboard[4,3]="w";
		
		Instantiate(wtokenObj, new Vector2(-3, 0), wtokenObj.rotation);
		Instantiate(wtokenObj, new Vector2(0, -3), wtokenObj.rotation);
		Instantiate(btokenObj, new Vector2(-3, -3), btokenObj.rotation);
		Instantiate(btokenObj, new Vector2(0, 0), btokenObj.rotation);
    }

    // Update is called once per frame
    void Update()
    { 
		for (int i =0 ; i < 8 ; i += 1)
        {
            for (int j =0 ; j < 8; j += 1)
            {
				if(String.Compare(newboard[i,j],board[i,j])!=0){
					if(String.Compare(newboard[i,j],"b")==0){
						Instantiate(btokenObj, new Vector2((i*3)-12, (j*3)-12), btokenObj.rotation);
						
						
					}
					else{
						Instantiate(wtokenObj, new Vector2((i*3)-12, (j*3)-12), wtokenObj.rotation);
						
					}
					board[i,j] = newboard[i,j];
				}
			}
			
		}
		if(legalMove()==0){
			if(curturn == "b"){
				curturn = "w";
			}
			else{
				curturn = "b";
			}
		}
		moveAI();
    }
	
	int legalMove(){
		int possibleMoves=0;
		for (int i =0 ; i < 8 ; i += 1)
        {
            for (int j =0 ; j < 8; j += 1)
            {
				if(String.Compare(newboard[i,j],"e")==0){
					possibleMoves += canPut(i,j); 
				}
			}
		}
		
		return possibleMoves;
	}
	
	
	int canPut(int I, int J)
	{	
		int changed = 0;
		//U
		int j=-1;
		for( j=J+1 ; j<8 ; j++){
			if(String.Compare(newboard[I,j], "e")==0 || String.Compare(newboard[I,j],curturn)==0){
				break;
			}
		}
		
		if( j!=8 && String.Compare(newboard[I,j],"e")!=0){
			changed +=j-J-1;
		}
		
		//D
		j=8;
		for( j=J-1 ; j>-1 ; j--){
			if(String.Compare(newboard[I,j], "e")==0 || String.Compare(newboard[I,j],curturn)==0){
				break;
			}
		}
		
		if( j!=-1 && String.Compare(newboard[I,j],"e")!=0){
			changed +=J-1-j;
		}
		
		//L
		int i=8;
		for( i=I-1 ; i>-1 ; i--){
			if(String.Compare(newboard[i,J], "e")==0 || String.Compare(newboard[i,J],curturn)==0){
				break;
			}
		}
		
		if( i!=-1 && String.Compare(newboard[i,J],"e")!=0){
			changed += I-1-i;
		}
		
		//R
		i=-1;
		for( i=I+1 ; i<8 ; i++){
			if(String.Compare(newboard[i,J], "e")==0 || String.Compare(newboard[i,J],curturn)==0){
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
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],curturn)==0){
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
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],curturn)==0){
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
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],curturn)==0){
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
			if(String.Compare(newboard[i,j], "e")==0 || String.Compare(newboard[i,j],curturn)==0){
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
	
	void moveAI(){
		if(curturn !="w"){
			string[,] temp = board; 
			//minimax tree
			minimax(temp,1,-1000000,1000000,"b");
			//find x y
			// add to new board
			newboard[bestX,bestY]="b";
			//check change
			newboard = checkTurn(bestX,bestY,newboard);
			for(int i=0; i<8; i++){
				for(int j=0; j<8; j++){
					Debug.Log(newboard[i,j]);
				}
			}
			curturn = "w";
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
