#include<stdio.h> 
void sort(int* a,int length) {
	int t;
	//ֻ��Ҫִ��length-1 �˼����ų���� 
	for(int i=0;i<length-1;++i){
		 
		for(int j=0;j<length-1;++j){ //��ѭ��ֻҪlength-i�˼��ɣ���Ϊÿ��ִ��һ�˹���ֻ��length-i������û������ 
			 
			if(a[j]>a[j+1]){
				t=a[j];
				a[j]=a[j+1];
				a[j+1]=t;
			}
		}
	}
	
	for(int i=0;i<length;++i){
		printf("%d ",a[i]);
	}
}
int main()
{
	int a[100] ={3,5,1,533}; 
	sort(a,4); 
}
