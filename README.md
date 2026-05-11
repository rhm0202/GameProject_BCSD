# SoulSlayer

> 2D 액션 플랫포머 | Unity 2D | 3인 팀 프로젝트

소울을 수집해 스킬 트리를 성장시키고 보스를 처치하는 2D 액션 플랫포머 게임입니다.

---

## 프로젝트 개요

| 항목 | 내용 |
|---|---|
| 장르 | 2D 액션 플랫포머 |
| 엔진 | Unity (URP 2D) |
| 개발 기간 | 약 5주 (2025.07 ~ 2025.08) |
| 팀 구성 | 3인 (류황민, 박근혁, 최수혁) |
| 플랫폼 | PC (Windows) |

---

## 다운로드

[▶ SoulSlayer 빌드 다운로드 (Windows)](https://github.com/rhm0202/GameProject_BCSD/releases/latest)

> 버그가 일부 존재할 수 있습니다.

---

## 조작법

| 키 | 동작 |
|---|---|
| `A / D` 또는 `←→` | 이동 |
| `Space` | 점프 |
| `Shift` | 대쉬 |
| `마우스 좌클릭` | 공격 |
| `X` | 포션 사용 |
| `ESC` | 일시정지 |

---

## 구현 시스템

### 플레이어
- 이동 / 점프 / 대쉬 / 공격 / 포션 사용
- 무적 대쉬 액티브 스킬 (소울 소모)
- 피격 히트박스 및 넉백

### 소울 시스템
- 적 처치 시 소울 드롭 및 획득
- 수집한 소울로 스킬 트리 해금

### 스킬 트리
- 패시브 스킬 트리 (단계별 스탯 강화)
- 액티브 스킬: 무적 대쉬

### 적 AI — 상태 머신 기반
```
일반 적:  Idle → Patrol → Chasing → Battle → Dead
Flower 적: Idle → Patrol → Battle (원거리 투사체)
보스 1:   Ready → Chasing → NAttack / JAttack → Rest
보스 2:   Ready → Chasing → NAttack / RAttack → Battle → Rest
```
- 투사체 오브젝트 풀링 적용

### UI
- 인게임 HUD: HP 바, 소울 보유량, 포션 개수
- 스킬 트리 UI
- 미니맵
- 일시정지 / 설정창
- 타이틀 화면 / 게임 오버 씬

### 체크포인트
- 도달 시 저장, 사망 시 해당 지점에서 리스폰

---

## 팀 역할 분담

| 이름 | 담당 |
|---|---|
| **류황민** | 플레이어, 스킬 트리 UI, HUD, 씬 구성, PR 관리 |
| **박근혁** | 적/보스 AI (상태 머신), 오브젝트 풀링, GameManager, SoundManager |
| **최수혁** | Stage1·2 맵 제작, 미니맵, 씬 전환 |

---

## 기술 스택

- **Engine**: Unity 2021 LTS, URP 2D
- **Language**: C#
- **Animation**: Spine 2D
- **협업**: GitHub (Feature 브랜치 전략, PR 코드 리뷰)

---

## 사용 에셋

- **환경/맵**: 2D Fantasy Sprite Bundle, Free Asset - 2D Handcrafted Art
- **캐릭터/적**: Fantazia Animated 2D Monsters
- **UI**: SharpUI, Animated Loading Icons, Clean Vector Icons
- **사운드**: Casual Game Sounds

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
