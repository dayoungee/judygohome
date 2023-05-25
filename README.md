# judy go home
<div style="color:blue">2017.07(1인 개발 프로젝트)</div>
judy go home.exe 실행파일, UnityPlyer.dll 파일, judy go home_data 디렉토리를 다운로드 받으면 플레이 가능합니다.
<img src="https://user-images.githubusercontent.com/55998706/70967525-cf87d880-20d9-11ea-8f3d-468c79a12b31.png"  width="600" height="400"/>

## 📘Technology Stack
- Clinet: Unity, C#

## 📌Summary
**Judy go home은 단일 스테이지로 점프가 필수 요소인 플랫포머 형식의 2D게임입니다.** 주디를 공격하는 몬스터들을 피하고, 박스를 이용하여 장애물을 건너야 합니다. 몬스터를 피격하거나 음식을 먹어 점수를 획득할 수 있으며, 집으로 도착해야 게임이 종료됩니다. 스코어 4,000점 이상, 목숨 3개 유지시 퍼펙트클리어 엔딩을 확인 할 수 있습니다.

 학부 시절, 자율 학습 위주의 수업으로 진행된 Unity 과목에서 실습 용으로 개발했습니다. 학술제 출품을 위해 이동만 가능했던 때와 다르게 아이템, 장애물, 몬스터, 특정 조건 만족 시 엔딩 추가 등 게임 성을 더하는 기능을 추가했습니다. 안드로이드와 PC환경에서 플레이 가능합니다.

 처음 만들어본 프로젝트이며, Unity에 대해서 공부할 수 있는 시간을 가지게 됐습니다. **개발이란 게 무엇인지 처음 깨닫게 해준 프로젝트입니다.**

 [협업 스터디 발표 상, 우수 상](https://www.notion.so/0bd7e3cf0b714210b3a623686e55a612)을 받았으며, [소프트웨어 학술제 공모전 2등](https://www.notion.so/540fd5c330614a10b948e90e4ccb7b9d)을 수상한 프로젝트입니다.
 
 오브젝트는 judy(plyaer), enmies, box, target, manager 로 구성되어 있으며 Sence은 타이틀, 스테이지, 게임오버, 게임 클리어, 퍼펙트게임 클리어 총 5개로 구성되어 있습니다. 에셋은 유니티 에셋 스토어의 무료 에셋인 sunnyland를 사용했습니다.
 
 ### 주요기능

- 아이템 획득 시 Score 100점 추가
- 캐릭터 이동, 점프 기능
- 몬스터와 접촉 시 목숨 1개 차감
- 몬스터 지정된 이동, 캐릭터 반경 내 진입 시 캐릭터를 따라 오는 이동
- Score 4000점 이상, 목숨 3개 유지 시 Perfect Clear 엔딩
- 몬스터 피격 기능
- 박스 이동 기능

## 🎨 Screenshot
<img src="https://user-images.githubusercontent.com/55998706/70035387-182d9500-15f6-11ea-9da6-18f21e53c6bb.png"  width="600" height="400"/>
<img src="https://user-images.githubusercontent.com/55998706/70967553-e0d0e500-20d9-11ea-92db-7a0e98530e45.png"  width="600" height="400"/>
<img src="https://user-images.githubusercontent.com/55998706/70967593-0362fe00-20da-11ea-9e04-f335454aaee9.png"  width="600" height="400"/>
<img src="https://user-images.githubusercontent.com/55998706/70967612-11b11a00-20da-11ea-9815-9da5128d24b9.png"  width="600" height="400"/>
<img src="https://user-images.githubusercontent.com/55998706/70967619-1675ce00-20da-11ea-94fa-9b8d13aaa14b.png"  width="600" height="400"/>
<img src="https://user-images.githubusercontent.com/55998706/70967636-2097cc80-20da-11ea-8259-378dadf70af7.png"  width="600" height="400"/>
<img src="https://user-images.githubusercontent.com/55998706/70967647-2b526180-20da-11ea-861f-4a581a3c69d3.png"  width="600" height="400"/>
<img src="https://user-images.githubusercontent.com/55998706/70967660-32796f80-20da-11ea-85e4-cc10b26daee5.png"  width="600" height="400"/>
<img src="https://user-images.githubusercontent.com/55998706/70967667-3dcc9b00-20da-11ea-8d13-226c32e59a1a.png"  width="600" height="400"/>
<img src="https://user-images.githubusercontent.com/55998706/70967728-6fddfd00-20da-11ea-8e56-c7dfb73b5c56.png"  width="600" height="400"/>

## 프로그램 구성
### 오브젝트 : 스크립트
judy(player) : Player_move, 몬스터(enemies) : Ememy1_move,
box : move, 집(target), 점수(manager) : manager
### Scene 구성 
타이틀, 스테이지, 게임오버, 게임클리어, 퍼펙트게임 클리어 (총 5개)
### 에셋
유니티 에셋 스토어의 무료에셋 sunnyland 사용
사운드는 인터넷 다운
