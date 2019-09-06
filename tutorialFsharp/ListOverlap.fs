module tutorialFsharp.ListOverlap

let listOverlap list1 list2 =
    Set.intersect (Set list1) (Set list2)