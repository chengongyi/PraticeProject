#include<stdio.h> 
int targetx=4,targety=3;
int minstep;
int book[51][51];

int a[51][51]={
		{0,0,1,0},
		{0,0,0,0},
		{0,0,1,0},
		{0,1,0,0},
		{0,0,0,1}
	};

 
void dfs(int x,int y,int step)
{
	printf("%d %d %d  %d %d \r\n",x,y,step,targetx,targety);
	
	printf("dfs:\r\n") ;
	
	int next[4][2]={{0,1},{1,0},{0,-1},{-1,0}};
	
	if(x==targetx &&y==targety)
	{
		if(step<minstep){
			minstep=step;
			return;
		} 
	}
	
	int nextx,nexty;
	for(int k=0;k<=3;k++)
	{ 
		nextx=x+next[k][0];
		nexty=y+next[k][1];
		
		//Խ���ж� 
		if(nextx<1 || nextx>6 ||nexty<1||nexty>5){
			continue;
		}
		
		//���������ж� ��ǣ���һ���������ǰ��� 
		if(a[nextx][nexty]==0 &&book[nextx][nexty]==0){
			book[nextx][nexty]=1;
			dfs(nextx,nexty,step+1);
			book[nextx][nexty]=0;
		}
	  
	}
	
	return;	
}
int main()
{
  	dfs(0,0,0);
  	book[0][0]=1;
	printf("%d",minstep);
	
	return 0;
}
