//
//  TestExample.m
//  Unity-iPhone
//
//  Created by MSK05 on 2017/04/25.
//
//
#import <Foundation/Foundation.h>
//プロダクトネーム-Swift.hのインポートをする。
#import "ProductName-Swift.h"

extern "C" {
    int _ex_addpedo() {
        int val;
        val = [TestExample startMethod];
        return val;
    }
    
    int _ex_returnval() {
        int retval;
        retval = [TestExample returnvalue];
        return retval;
    }
    int _ex_HistPedometer() {
        int retvalue;
        retvalue = [TestExample callHist];
        return retvalue;
    }
    
    const char* _ex_TodayStart() {
        
        NSString *dateString = [TestExample toDayStartTimes];
        
        const char* retrunDate = (char *) [dateString UTF8String];
        NSLog(@"ちょっと変換後 %s", retrunDate);
        char* retStr = (char*)malloc(strlen(retrunDate) + 1);
        
        strcpy(retStr, retrunDate);
        NSLog(@"色々変換後 %s",retStr);
        return retStr;
    }
}
