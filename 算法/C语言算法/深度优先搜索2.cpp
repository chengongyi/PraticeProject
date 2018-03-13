#include<stdio.h>
int n,m,p,q,min=999999999;
int a[51][51],book[51][51];

void dfs(int x,int y,int step){
	//定义四个方向 上下左右 
	int next[4][2]={{0,1},{1,0},{0,-1},{-1,0}};
	
	int tx,ty,k;
	
	//判断当前是找到了小哈 
	if(x==p && y==q){
		if(step<min){
			min=step;
		}
		return;
	}
	
	//循环遍历四个方向，找到对应的四个坐标 
	for(k=0;k<=3;k++){
		tx=x+next[k][0];
		ty=y+next[k][1];
		
		//判断是否越界了 
		if(tx<1 ||tx>n || ty<1||ty>n){
			continue;
		}
		
		//判断当前位置是否还没有被探索，如果是，则记录一下，
		//处理好了当前的一点， 
		if(a[tx][ty]==0 &&book[tx][ty]==0){
			book[tx][ty]=1;
			dfs(tx,ty,step+1);
			book[tx][ty]=0;
		}
	}
}

int main()
{
	int i,j,startx,starty;
	 
	n=5;
	m=4; 
	
	freopen("data1.in","r",stdin);
	
	printf("录入数组:\r\n");
	for(i=1;i<=n;i++){
		for(j=1;j<=m;j++){
			scanf("%d",&a[i][j]);
		}
	}
	 
	startx=1;
	starty=1;
	p=4;
	q=4;
	
	book[startx][starty]=1;
	
	dfs(startx,starty,0);
	
	printf("%d",min);
}
