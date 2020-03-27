# Algorithm problem
Input: Polish notation\
Output: Summarized version

1. It seems we are only asked to summarize the numerical expressions. 
2. For example, we could summarize operations with zero and one, but the problem has not asked. 
3. We start from the end of the expression and copy the segments to the destination list, reversely. 
4. We calculate the sub-expression by facing a sequence of "n numbers followed by m operators" using stack, 
Then, we add the result to the destination list and continue. 
5. At the end, the result is the reverse of the destination list.
