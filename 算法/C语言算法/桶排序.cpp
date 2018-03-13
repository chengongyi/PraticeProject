#include<stdio.h>
int main()
{
	int a[11],i,j,t;
	
	//把桶清理干净 
	for(i=0;i<=10;++i){
		a[i]=0;
	}
	
	//输入5个数字 
	for(i=0;i<5;++i) {
		scanf("%d",&t);
		++a[t];
	}
	
	//循环所有准备的桶，依次遍历，查看每个桶里有多少个数字 
	for(i=0;i<=10;++i){
		for(j=1;j<=a[i];++j){
			printf("%d",i);
		}
	}
	
	getchar();
	return 0;
}
