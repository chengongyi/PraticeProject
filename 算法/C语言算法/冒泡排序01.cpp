#include<stdio.h> 
void sort(int* a,int length) {
	int t;
	//只需要执行length-1 趟即可排出结果 
	for(int i=0;i<length-1;++i){
		 
		for(int j=0;j<length-1;++j){ //内循环只要length-i趟即可，因为每次执行一趟过后，只有length-i个数据没有排序 
			 
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
