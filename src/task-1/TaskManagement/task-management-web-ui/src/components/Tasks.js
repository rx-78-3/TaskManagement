import React, { useState, useEffect, useCallback } from 'react';
import api from '../services/api';
import Pagination from './Pagination';

function Results() {
    const [tasks, setTasks] = useState([]);
    const [page, setPage] = useState(0);
    const [pageSize] = useState(10);
    const [totalCount, setTotalCount] = useState(0);

    const fetchResults = useCallback(async () => {
        try {
            const response = await api.get('/tasks', {
                params: { Page: page, PageSize: pageSize }
            });
            setTasks(response.data.data);
            setTotalCount(response.data.totalCount);
        } catch (error) {
            console.error('Data load error', error);
        }
    }, [page, pageSize]);

    useEffect(() => {
        fetchResults();
    }, [fetchResults]);

    return (
        <div className="container">
            <table className="table mt-3">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Status</th>
                        <th>Created At</th>
                        <th>Updated At</th>
                    </tr>
                </thead>
                <tbody>
                    {tasks.map((task) => (
                        <tr key={task.id}>
                            <td>{task.name}</td>
                            <td>{task.description}</td>
                            <td>{task.status}</td>
                            <td>{new Date(task.createdAt).toLocaleString()}</td>
                            <td>{task.updatedAt ? new Date(task.updatedAt).toLocaleString() : 'N/A'}</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <div className="mt-3">
                <Pagination 
                    currentPage={page} 
                    totalCount={totalCount} 
                    pageSize={pageSize} 
                    onPageChange={setPage} 
                />
            </div>
        </div>
    );
}

export default Results;