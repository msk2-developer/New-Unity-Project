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
    //歩数計測
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
    //歩数セッター
    private func setPedoresult(pedoresult :Int) {
        TestExample.pedoresult = pedoresult
    }
    //歩数ゲッター
    static private func getPedoresult() ->Int {
        return TestExample.pedoresult
    }
    //スタート時に呼ぶ
    static func startMethod() -> Int{
        var result :Int
        TestExample().viewDidLoad()
        result = TestExample.pedoresult
        print(result)
        return result
        
    }
    //更新された歩数を取得
    static func returnvalue() ->Int{
        var returnvalue :Int
        returnvalue = TestExample.getPedoresult()
        return returnvalue
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    //とりあえず出力用
    var hist :Int = 0
    var toDay :Int = 0
    func showHistory() -> Int{
        print(self.hist)
        self.toDay = self.pedometerQuery()
        return self.toDay
    }
    
    public static func callHist() -> Int{
        let returnvalue :Int = TestExample().showHistory()
        return returnvalue
    }
    
    /**
     歩数計に関する１日分の情報を返します。
     :returns: 歩数計に関する情報
     */
    func pedometerQuery() -> Int {
        var result :Int = 0
        
        let pedometer:CMPedometer = CMPedometer()
        if(!CMPedometer.isStepCountingAvailable()) {
            return result
        }
        
        let now:NSDate = NSDate()
        let formatter:DateFormatter = DateFormatter()
        formatter.dateFormat = "yyyy-MM-dd"
        var from:NSDate = self.stringToDate(date: formatter.string(from: now as Date), isStart: true)
        var to:NSDate = self.stringToDate(date: formatter.string(from: now as Date), isStart: false)
        
        let semaphore = DispatchSemaphore(value: 0)
        
        pedometer.queryPedometerData(from: from as Date, to: to as Date, withHandler: {(data, error) in
            result = Int((data?.numberOfSteps)!);
            //いろんなデータ
            // "distance"+pedometerData.distance! +
            // "floorsAscended"+ pedometerData.floorsAscended! +
            // "floorsDescended"+ pedometerData.floorsDescended! +
            // "startDate"+ pedometerData.startDate +
            // "endDate"+ pedometerData.endDate
            semaphore.signal()
        })
        semaphore.wait()
        
        from = self.dateByAddingDay(date: from, day: -1)
        to = self.dateByAddingDay(date: to, day: -1)
        print(result);
        return result
    }
    
    /**
     指定した日付に時分秒を追加して新しいNSDateを返します。
     
     :param: date もとのNSDate
     :param: isStart trueのとき00:00:00、falseのとき23:59:59を追加します
     :returns: 新しいNSDate
     */
    private func stringToDate(date: String, isStart: Bool) -> NSDate {
        let timestamp = (isStart) ? date + " 00:00:00" : date + " 23:59:59"
        let formatter:DateFormatter = DateFormatter()
        formatter.dateFormat = "yyyy-MM-dd HH:mm:ss"
        return formatter.date(from: timestamp)! as NSDate
    }
    
    /**
     指定した日数を加減した新しいNSDateを返します。
     
     :param: date もとのNSDate
     :param: day 加減する日数
     :returns: 新しいNSDate
     */
    private func dateByAddingDay(date: NSDate, day: Int) -> NSDate {
        let calendar:NSCalendar = NSCalendar.current as NSCalendar
        let components:NSDateComponents = NSDateComponents()
        components.day = day
        return calendar.date(byAdding: components as DateComponents, to: date as Date) as NSDate!
    }
    
    /**
     開始した日付を取得
     */
    static func toDayStartTimes() -> NSString{
        let now = NSDate() // 現在日時の取得
        let dateFormatter = DateFormatter()
        dateFormatter.locale = NSLocale(localeIdentifier: "en_US") as Locale! as Locale! // ロケールの設定
        dateFormatter.dateFormat = "yyyy/MM/dd HH:mm:ss" // 日付フォーマットの設定
        print(dateFormatter.string(from: now as Date))
        
        return dateFormatter.string(from: now as Date) as NSString
        
    }
}
