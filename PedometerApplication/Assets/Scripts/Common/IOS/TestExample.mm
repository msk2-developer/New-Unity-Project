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
        retval = (int)[TestExample returnvalue];
        return retval;
    }
    int _ex_HistPedometer() {
        int retvalue;
        retvalue = [TestExample callHist];
        return retvalue;
    }
}
