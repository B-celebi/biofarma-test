package org.testbiofarma;

import java.util.HashSet;

public class Main {
    public static void main(String[] args) {
        int[][] multiArr = new int[7][2];
        multiArr[0][0] = 1;
        multiArr[0][1] = 2;
        multiArr[1][0] = 3;
        multiArr[1][1]=7;
        multiArr[2][0]=0;
        multiArr[2][1]=6;
        multiArr[3][0]=1;
        multiArr[3][1]=1;
        multiArr[4][0]=-5;
        multiArr[4][1]=2;
        multiArr[5][0]=1;
        multiArr[5][1]=5;
        multiArr[6][0]=3;
        multiArr[6][1]=-5;

        HashSet<Integer> countX = new HashSet<Integer>();
        HashSet<Integer> countY = new HashSet<Integer>();
        for(int i = 0; i<multiArr.length; i++){

            for(int j = 0;j<multiArr.length; j++){
                if(j==i){
                    continue;
                }
                if(multiArr[i][0]==multiArr[j][0]){
                    countX.add(multiArr[i][0]); //Xleri aynı olan (yani y'ye paralel olan doğrular.)
                }
            }
            for(int z=0; z<multiArr.length; z++){
                if(z==i){
                    continue;
                }
                if(multiArr[i][1]==multiArr[z][1]){
                    countY.add(multiArr[i][1]); //Yleri aynı olan (yani x'e paralel olan doğrular.)
                }
            }

        }
        System.out.println("X koordinatları aynı olan(yani Y'ye paralel olan) doğru sayısı : " + countX.size());
        System.out.println("Y koordinatları aynı olan(yani X'e paralel olan) doğru sayısı " + countY.size());

    }
}