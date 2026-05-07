# SoulSlayer

> 2D 액션 플랫포머 | Unity 2D | 3인 팀 프로젝트

소울을 수집해 스킬 트리를 성장시키고, 스테이지 보스를 처치하는 2D 액션 플랫포머 게임입니다.

---

## 게임 개요

| 항목 | 내용 |
|---|---|
| 장르 | 2D 액션 플랫포머 |
| 엔진 | Unity (URP 2D) |
| 개발 기간 | 2025.07 ~ 2025.08 |
| 팀 구성 | 3인 (플레이어/UI, 적/보스, 맵) |
| 플랫폼 | PC (Windows) |

---

## 핵심 게임플레이

- **소울 수집 시스템**: 적 처치 시 소울 드롭, 수집한 소울로 스킬 트리 해금
- **스킬 트리**: 패시브 스킬 + 액티브 스킬(무적 대쉬) 구성
- **2개 스테이지**: 스테이지별 고유 맵과 보스 존재
- **체크포인트**: 스테이지 중간 저장 지점

---

## 조작법

| 키 | 동작 |
|---|---|
| `A / D` 또는 `←→` | 이동 |
| `Space` | 점프 |
| `Shift` | 대쉬 |
| `Z` | 공격 |
| `X` | 포션 사용 |
| `ESC` | 설정 메뉴 |

---

## 구현 시스템

### 플레이어
- 이동 / 점프 / 대쉬 / 공격
- 무적 대쉬 액티브 스킬 (소울 소모)
- 포션 사용 (체력 회복)
- 피격 히트박스 및 넉백

### 적 AI — 상태 머신 기반
각 적은 독립적인 State Machine으로 동작합니다.

```
일반 적:  Idle → Patrol → Chasing → Battle → Dead
Flower 적: Idle → Patrol → Battle (원거리 공격)
보스 1:   Ready → Chasing → NAttack / JAttack → Rest
보스 2:   Ready → Chasing → NAttack / RAttack → Battle → Rest
```

- **Enemy_Grounded**: 순찰 + 플레이어 추적 근접 공격
- **Enemy_Flower**: 고정 위치 원거리 투사체 공격
- **Boss_Stage1**: 패턴 전환형 근접 보스
- **Boss_Stage2**: 근거리 + 원거리 혼합 패턴 보스
- 오브젝트 풀링으로 투사체 성능 최적화

### UI / 스킬 트리
- 플레이어 HP 바 실시간 동기화
- 소울 수집량 표시 및 관리
- 패시브 스킬 트리 UI (소울 소모 해금)
- 미니맵
- 설정창 (열기/닫기)

### 씬 구성
타이틀 → Stage1 → Stage2 → 게임 오버

---

## 기술 스택

- **Engine**: Unity 2021 LTS, URP 2D
- **Language**: C#
- **Animation**: Spine 2D
- **협업**: GitHub (Feature 브랜치 전략, PR 코드 리뷰)

---

## 팀 역할 분담

| 이름 | 담당 |
|---|---|
| **류황민** | 플레이어 시스템 (이동/대쉬/포션), 스킬 트리 UI, 타이틀·게임오버 씬, 체크포인트, PR 관리 |
| **박근혁** | 적/보스 AI (상태 머신), 오브젝트 풀링, GameManager, SoundManager |
| **최수혁** | Stage1·2 맵 제작, 미니맵, 씬 전환 |

---

## 프로젝트 구조

```
Assets/
├── Feature_Player/      # 플레이어 이동, 공격, 리소스
├── Feature_Enemy/       # 적 AI, 보스, 상태 머신
│   └── Scripts/State/   # 각 적별 상태 클래스
├── Feature_UI/          # HUD, 스킬 트리, 설정창
├── Feature_Manager/     # GameManager, SoundManager
├── Feature_CheckPoint/  # 체크포인트 시스템
├── Feature_Title/       # 타이틀 씬
└── Map/                 # 스테이지 씬
```

---

## GitHub

[https://github.com/rhm0202/GameProject_BCSD](https://github.com/rhm0202/GameProject_BCSD)
