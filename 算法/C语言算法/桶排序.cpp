#include<stdio.h>
int main()
{
	int a[11],i,j,t;
	
	//��Ͱ����ɾ� 
	for(i=0;i<=10;++i){
		a[i]=0;
	}
	
	//����5������ 
	for(i=0;i<5;++i) {
		scanf("%d",&t);
		++a[t];
	}
	
	//ѭ������׼����Ͱ�����α������鿴ÿ��Ͱ���ж��ٸ����� 
	for(i=0;i<=10;++i){
		for(j=1;j<=a[i];++j){
			printf("%d",i);
		}
	}
	
	getchar();
	return 0;
}
