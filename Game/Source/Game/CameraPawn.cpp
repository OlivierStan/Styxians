// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraPawn.h"
#include "Camera/CameraComponent.h"
#include "GameFramework/SpringArmComponent.h"

#include "GridManagerSubsystem.h"

// Sets default values
ACameraPawn::ACameraPawn()
{
    PrimaryActorTick.bCanEverTick = false;

    SceneRoot = CreateDefaultSubobject<USceneComponent>(TEXT("SceneRoot"));
    RootComponent = SceneRoot;

    SpringArm = CreateDefaultSubobject<USpringArmComponent>(TEXT("SpringArm"));
    SpringArm->SetupAttachment(SceneRoot);
    SpringArm->TargetArmLength = ArmLength;
    SpringArm->SetRelativeRotation(FRotator(PitchAngle, 0.f, 0.f));
    SpringArm->bDoCollisionTest = false;

    Camera = CreateDefaultSubobject<UCameraComponent>(TEXT("Camera"));
    Camera->SetupAttachment(SpringArm, USpringArmComponent::SocketName);
}

// Called when the game starts or when spawned
void ACameraPawn::BeginPlay()
{
	Super::BeginPlay();

    if (APlayerController* PC = Cast<APlayerController>(GetController()))
    {
        PC->bShowMouseCursor = true;
        PC->bEnableClickEvents = true;
        PC->bEnableMouseOverEvents = true;
    }

    EnableInput(Cast<APlayerController>(GetController()));
    if (InputComponent)
    {
        InputComponent->BindAction("DebugClick", IE_Pressed, this, &ACameraPawn::DebugTestGridClick);
    }
	
}

void ACameraPawn::DebugTestGridClick()
{
    if (UGridManagerSubsystem* Grid = GetWorld()->GetSubsystem<UGridManagerSubsystem>())
    {
        FHitResult Hit;
        if (GetWorld()->GetFirstPlayerController()->GetHitResultUnderCursor(ECC_Visibility, false, Hit))
        {
            FIntPoint Cell = Grid->WorldToGrid(Hit.Location);
            UE_LOG(LogTemp, Warning, TEXT("Clicked cell: %d, %d"), Cell.X, Cell.Y);
        }
    }
}