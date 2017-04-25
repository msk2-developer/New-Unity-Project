//
//  ViewTest.swift
//  Unity-iPhone
//
//  Created by MSK05 on 2017/04/25.
//
//

import UIKit
import CoreMotion

class TestExample: UIViewController {
    
    
    // class wide constant !!
    let pedometer = CMPedometer()
    static var pedoresult :Int = 0
    
    override func viewDidLoad(){
        super.viewDidLoad()
        // CMPedometerの確認
        if(CMPedometer.isStepCountingAvailable()){
            self.pedometer.startUpdates(from: NSDate() as Date) {
                (data: CMPedometerData?, error) -> Void in
                DispatchQueue.main.async(execute: { () -> Void in
                    if(error == nil){
                        // 歩数
                        let steps = data!.numberOfSteps
                        TestExample.pedoresult = Int(steps)
                        print(TestExample.pedoresult)
                        self.setPedoresult(pedoresult: TestExample.pedoresult)
                    }
                })
            }
        }
        
    }
    
    private func setPedoresult(pedoresult :Int) {
        TestExample.pedoresult = pedoresult
    }
    
    static private func getPedoresult() ->Int {
        return TestExample.pedoresult
    }
    static func startMethod() -> Int{
        var result :Int
        TestExample().viewDidLoad()
        result = TestExample.pedoresult
        print(result)
        return result
        
    }
    
    static func returnvalue() ->Int{
        var returnvalue :Int
        returnvalue = TestExample.getPedoresult()
        return returnvalue
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
}
