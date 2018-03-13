#include<stdio.h> 

struct node
{
	int x;//横坐标 
	int y;//纵坐标 
	int f;//父亲节点 
	int s;//步数 
};

int main()
{
	struct node que[2501];
	
	int a[51][51]={0};
	int book[51][51]={0};
	int next[4][2]={{0,1},{1,0},{0,-1},{-1,0}};
	int head,tail;
	int i,j,k,n,m,startx,starty,p,q,tx,ty,flag;
	
	n=5;
	m=4; 
	
	freopen("data1.in","r",stdin);	
	
	for(i=1;i<=n;i++){
		for(j=1;j<=m;j++){
			scanf("%d",&a[i][j]);
		}
	}
		
	startx=1;
	starty=1;
	p=4;
	q=3;
	
	head=1;
	tail=1;
	
	que[tail].x=startx;
	que[tail].y=starty;
	que[tail].f=0;
	que[tail].s=0;
	
	tail++;
	book[startx][starty]=1;
	
	flag=0;
	
	while(head<tail){
		for(k=0;k<=3;k++){
			tx=que[head].x+next[k][0];
			ty=que[head].y+next[k][1];
			
			if(tx<1||tx>n||ty<1||ty>m){
				continue;
			}
			
			if(a[tx][ty]==0 && book[tx][ty]==0){
				book[tx][ty]=1;
				que[tail].x=tx;
				que[tail].y=ty;
				que[tail].f=head;
				que[tail].s=que[head].s+1;
				tail++;
			}
			
			if(tx==p && ty==q){
				flag=1;
				break;
			}
			
		}
		
		if(flag==1){
			break;
		}
		head++;
	}
	
	printf("%d",que[tail-1].s);
	
	for(i=1;i<=tail;i++){
		printf("%d",que[tail].f);
	}
}
