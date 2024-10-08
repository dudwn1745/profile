## 보유한 스킬
* JAVA
  * Spring Boot 3.2.2 on JDK 17
  * Spring Boot 2.2.7 on JDK 8
* ASP.NET
  * .NET Core 8.0
  * .NET Core 6.0
  * Rest API, Grpc
  * .NET Framework 4.5 MVC
  * Entity Framework, Dapper, Stored Procedure(SP)
  * JQeury, JavaScript, Alpine.js
* 데이터 베이스
  * MSSQL, MySQL
* 디자인 패턴
  *  DDD 패턴, CQRS 패턴, 중재자(Mediator) 패턴, MVC 패턴
* 기타
  * xunit 테스트 코드
  * Azure 클라우드 - key Valult, devops, logic app, application insight log, kusto Query, Front door, load balancer 기타 등등

## 경력기술서에 작성한 샘플 코드 스타일
[README 이동하기](https://github.com/dudwn1745/profile/blob/master/README2.md)

## 경력 기술서
- [잼팟(넷마블)](#잼팟-넷마블)
- [지오시스(큐텐)](#지오시스-큐텐)
- [오르비텍](#오르비텍)
- [브이트론](#브이트론)

## 잼팟-넷마블
### 윈조이 포털, KSOP, 오피셜 등의 신규 웹 사이트 및 api 개발
#### 1. 윈조이 포털 사이트 (Asp.Net MVC)
- 윈조이 포털 사이트의 유지 보수 및 CMS에서 요청하는 API 신규 개발
- 잼팟 오피셜 사이트의 신규 개발 및 Azure Application Insight 적용
- 채용 공고 페이지의 Ajax 페이징 처리 및 PC/Mobile 구분하여 페이지 작업 처리

#### 2. 관리자용 WPL CMS 개발 (ASP.NET CORE)
- 구글 OTP 라이브러리를 사용한 2차 인증 구현
- 신규 WPL CMS 사이트 개발, 클린 아키텍처와 ASP.NET Core 기반의 로그인 인증 프로세스 구현
- 애저 스토리지 테이블 및 Kusto 쿼리를 활용한 오류 모니터링 로직 앱 개발

#### 3. 유저용 KSOP 사이트 개발 (ASP.NET CORE)
- 클린 아키텍처 및 DDD 패턴을 적용한 백엔드 API 개발 및 Swagger 적용
- JWT 토큰 기반의 로그인 프로세스 구현 및 구글 OTP 라이브러리를 사용한 2차 인증 구현
- 애저 데브옵스를 활용한 CI/CD 구축
- EF Core를 활용한 유저 및 대회 관련 데이터 처리 및 단위 테스트 수행

#### 4. 관리자용 KSOP CMS 개발 (JAVA)
개발환경: MySQL, Java Spring Framework
- MVC 패턴을 활용한 대회 및 갤러리 관리 프로그램 개발
- JPA ORM을 이용한 데이터 관리 및 부트스트랩을 활용한 HTML 개발

## 지오시스-큐텐 (ASP.NET)
### 배송 트래킹 관련 백엔드 프로그램 프론트 UI 웹 서비스 및 API 개발
#### 1. 배송 트래킹 관련
- 쇼핑몰 내 판매자/구매자들에게 배송 상태를 제공하기 위한 트래킹 시스템 구축
- 큐텐 사이트의 택배사 페이지에서 송장번호를 입력하여 결과를 표시하는 프론트 UI 개발
- RESTful API를 활용하여 택배사 페이지 크롤링 및 데이터 처리
- 다양한 택배사 업체의 API를 연동하여 입고, 송장 출력, 배송 트래킹 기능 구현
- 배송 상태 업데이트를 위한 SP(저장 프로시저) 작성 및 실행
#### 2. 프론트 UI 및 API 개발
- QSM(Qoo10 Seller Management)에서 번들세일 프로모션 관리페이지 개발
- 프로모션 타입별 우선순위 입력, 여러 체크 과정 처리
- 모바일 메인 페이지 개편 작업으로 페이지 로드 속도 개선 및 데이터 관리 개선
- 웹서비스 및 API를 활용하여 페이지 내 공통 데이터 조회 및 처리
- SP를 사용하여 프로모션 신청, 취소 등의 업무 처리

## 오르비텍 - 1인 개발 회사 (Visual Studio C++)
TLD 방사선 프로그램 개발 및 하드웨어 관리

개발언어 - Visual C++, MSSQL, svn
TLD 판독 프로그램 개발
- 병원 및 방사능 업무에 종사하는 분들의 경우 항상 방사능 위험에 노출되어 있으므로 TLD 뱃지를 착용하도록 되어있는데
이 TLD 를 수거하여 판독 하는 프로그램을 개발

(1) 매일 아침 디비 백업을 수행

(1) TLD 장비에서 16진수로 된 코드값을 보내주는데 4개의 패킷 크기로 나눠 각 테이블 컬럼에 맞게 저장되도록 작업을 수행

(2) 받은 데이터는 각 지역별 및 업무에 따라 계산하는 4개의 알고리즘이 존재하는데 스펙에 맞게 알고리즘을 개발 및 적용

(3) 계산한 결과값을 엑셀파일에 저장하여 매 분기마다 고객들에게 발송

(4) UAE 국가에 TLD 판독장비를 수출하여 UAE에 맞는 알고리즘 개발 및 영문버전 프로그램 개발 및 영문버전용 테이블 생성

## 브이트론 (xFrame, Visual Studio C++)
KTX 예약발매 및 고장 코드 무선 전송 장치 프로그램 개발

예약발매시스템 개량 및 API 구축

SRT 열차프로젝트에 참가하여 KCC정보통신의 PM을 주최로 하여 20명 이상의 개발자가 참석하였으며, 웹개발, 서버개발, 단말기, 자동단말기 개발을 하였으며 그중 저의 담당은 단말기와 자동발매기를 담당하였으며, 역내의 있는 발매기의 프로그램을 개발 및 보수

개발언어로는 xFrame, javascript 를 주로 사용하였으며, 기본적인 UI이 뿐만 아니라 각 화면에 맞는 기능을 추가하였습니다.

KTX 고장코드 무선전송장치 프로그램

회사에서 자체 개발한 프로그램으로 KTX 기관사 옆 자리에 위치한 PDA에서 열차 고장시 고장코드를 수신 받아 원격으로 코드를 전송해주는 프로그램을 개발

기존에 KTX에만 사용하였으나, 이번에 새로 SRT 열차가 편성되면서, 무선전송장치 PDA를 SRT 열차에 맞게 프로그램 수정 및 유지보수
