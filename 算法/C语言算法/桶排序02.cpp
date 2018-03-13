#include<stdio.h> 
int main()
{
	int book[1001],i,j,t,n;
	scanf("%d",&n);
	for(i=0;i<1001;++i){
		book[i]=0;
	}
	
	for(i=0;i<n;++i){
		scanf("%d",&t);
		++book[t];
	}
	
	for(i=0;i<=1000;++i){
		for(j=1;j<=book[i];++j){
			printf("%d ",i);
		}
	}
}
