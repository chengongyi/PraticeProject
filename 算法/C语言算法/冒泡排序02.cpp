#include<stdio.h>
typedef  struct Student
{
	char name[21];
	int score;
}Student;

void sort(Student *a,int length)
{
	for(int i=0;i<length;++i){
		printf("name=%s score=%d ",a[i].name,a[i].score);
	}
}

int main()
{
	Student a[100]={
	{"AA",100},
	{"BB",90},
	{"CC",98},
	};
	
	sort(a,3);
}
