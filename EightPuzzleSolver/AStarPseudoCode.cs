
#region pseudocode

// A* Algorithm
// ---------------------------------------------------------------------------
// -initialize the open list
// -initialize the closed list
// put the starting node on the open list (you can leave its f at zero)
//
// while the open list is not empty
//    find the node with the least f on the open list, call it "q"
//    pop q off the open list
//    generate q's 8 successors and set their parents to q
//    for each successor
//        if successor is the goal, stop the search
//        successor.g = q.g + distance between successor and q
//        successor.h = distance from goal to successor
//        successor.f = successor.g + successor.h
//
//        if a node with the same position as successor is in the OPEN list
//            which has a lower f than successor, skip this successor
//        if a node with the same position as successor is in the CLOSED list 
//            which has a lower f than successor, skip this successor
//        otherwise, add the node to the open list
//    end
//    push q on the closed list
// end
// ---------------------------------------------------------------------------

#endregion

