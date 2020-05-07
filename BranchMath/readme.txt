
=============================================BranchMath=========================================

The name BranchMath comes from two different ideas:
	1) That this software should encompass as many branches of mathematics as possible
	2) The operation TREE should be the center of attention in this project

The operation tree is intended to be able to perform operations on not only numbers but on any possible mathematical object which can be implemented in code.

As of now, some basic frameworks are being developed. In particular, we are finding the most efficient way to represent our tree and the objects which can be contained. 

==============================================Goals=============================================

The primary goals of this project:
	+ Be able to manipulate many mathematical objects with implementation of new objects being easy and intuitive.
	+ Be able to represent operations in abstract form with an operation tree
	+ Be able to manipulate the operation tree into a unique normal form in as many cases as possible
	+ Be able to translate the operation tree to and from LaTeX
	+ Be able to translate the operation tree to and from plaintext function representation
	+ Be able to represent operation tree using a variety of different GUIs and PTUIs
	+ Network this software such that a client can perform this operations online if a server is running
	+ Use parallelism to efficiently perform calculations where possible
	+ Be both as general and as precise as possible
	+ Implement many algorithms for numerical computations and exact simplifications
	+ Be able to isolate variables and solve equations numerically and exactly
	+ Use a database to store simplification and conversion rules and import them into the program as relevant functions are used

===========================================Structure============================================

ValueType - Represents a mathematical object (e.g. a real number, a group, a function)
	+ Functions are treated identically to other objects


Node - Represents a node in the operation tree
	+ Comes in 3 varieties: Constant, Variable, and Mapping 
	+ Constant - holds precisely one value and does not change
	+ Variable - is a leaf of an operation tree and can be assigned a value at any point
	+ Mapping - is not a leaf and takes in inputs from children nodes to determine its value


SimplificationRule - Given a MappingNode, identify certain substructure that allows it to be put in a normal form
	+ No simplification rules should be hardcoded in the long run
	+ TODO: Create a format for which rules can be inputted and outputted by a user without hardcoding 
	+ TODO: Create a dictionary of simplification rules and an algorithm to extract rules based on the operations used in the tree


TODO: ConversionRule - Represents a rule for converting a certain type of LaTeX expression to a Node (e.g. $\begin{bmatrix} 1\\2\\3 \end{bmatrix}$ => new Vector<Number>(new Number(1), new Number(2), new Number(3))
	+ TODO: Create a dictionary of conversion rules and an algorithm to extract rules based on the commands used in the LaTeX


==========================================Normal Forms==========================================


We still need to determine precisely what our preferred normal forms are, but ideally they are not necessarily the smallest tree, but rather the most useful for algebraic manipulation. Potentially, the rule could be that the primary focus independent variable should appear in as few nodes as possible, ideally precisely one.


================================================================================================
