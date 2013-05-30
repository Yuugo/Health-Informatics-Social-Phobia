#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int sud(int x, double delta){
	double a = -0.000005;
	double b = x-900;
	double c = 5 * delta;
	double r = a*b*b+c;
	return (int)r;
}

int gsr(int x, double delta){
	double a = -0.0001;
	double b = x-900;
	double c = 545 * delta;
	double r = a*b*b+c;
	return (int)r;
}

int hr (int x, double delta){
	double a = -0.00003;
	double b = x-900; 
	double c = 75 * delta;
	double r = a*b*b+c; 
	return (int)r; 
}

int main()
{
    srand(time(NULL));
    printf("TimeStamp\tHeartRate\t\tGSR\t\tSUD\n");
    int hour =   15;
    int minute = 00;
    int second = 00;
	double delta = 1.50;
	
    for(int i = 0;i<1800;i++){
        second++;
        if(second>=60){
          second = 0;
          minute++;             
        }
        if(minute>=60){
          minute = 0;
          hour++;
        }
        if(hour>=24){
          hour = 0;
        }
        printf("%02d:%02d:%02d\t",hour,minute,second);
        printf("%d\t",hr(i,delta));//heartrate
        printf("%d\t",gsr(i,delta));//GSR
        if(minute%3==0&&second==0)
         printf("%d",sud(i,delta));//SUD
        printf("\n");
    }
}
