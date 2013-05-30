#include <stdio.h>
#include <stdlib.h>
#include <time.h>
int main()
{
    srand(time(NULL));
    printf("TimeStamp\tHeartRate\t\tGSR\t\tSUD\n");
    int hour =   rand() %24; 
    int minute = rand()%60;
    int second = rand()%60;
    int i;
    for(i = 0;i<1800;i++){
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
        printf("%d\t",65+rand()%20);//heartrate
        printf("%d\t",860+rand()%40);//GSR
        if(minute%3==0&&second==0)
         printf("%d",1+rand()%10);//SUD
        printf("\n");
    }
}
